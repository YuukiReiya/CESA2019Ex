using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MethodExpansion;

//  名前空間で区切ること！
namespace Game.Enemy
{
    public class Enemy : MonoBehaviour
    {
        //変数
        //一秒当たりの回転角度
        public float _angle = 30f;
        int x = 1;
        //--------------------------------------------
        //  番場 編集
        [SerializeField] float _stunTime;   //スタン時間

        //--------------------------------------------

        //回転の中心をとるために使う変数
        [SerializeField] private GameObject target;

        // Start is called before the first frame update
        void Start()
        {

            //自分をZ軸を中心に0～360でランダムに回転させる
            // transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)), Space.World);
            this.transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)), _angle);

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            {
                //collision.gameObject.transform.rigidbody2D.isKinematic = true;
            }
            //  レイヤーの当たり判定
            if (9 != collision.gameObject.layer)
            {
                //Player以外のレイヤーの当たり判定をとらない
                return;

            }

            Debug.Log("当たってる");

            //--------------------------------------------
            //  番場 編集
            PrePro.Player.PlayerController player = null;
            try
            {
                player = collision.GetComponent<PrePro.Player.PlayerController>();
            }
            catch
            {
                Debug.LogError("Player取得で例外発生");
            }

            //  攻撃中？
            if (player.isAttack)
            {
                //  敵オブジェクト破棄
                Destroy(this.gameObject);
            }
            else
            {
                //  酸素ゲージ減少
                player.DamageOxygen(20);
            }
            //--------------------------------------------

            //x = 0;

        }

        //--------------------------------------------
        //  番場 編集
        public void Stun()
        {
            x = 0;
            this.DelayMethod(() => { x = 1; }, _stunTime);
        }
        //--------------------------------------------



        // Update is called once per frame
        void Update()
        {

            //	Sampleを中心に自分を現在の上方向に、毎秒angle分だけ回転する。
            Vector3 axis = transform.TransformDirection(new Vector3(0, 0, 1));
            transform.RotateAround(target.transform.position, axis, _angle * x * Time.deltaTime);

            if (Input.GetKey(KeyCode.Space))
            {
                //Space押したら敵が消える
                Destroy(this.gameObject);
            }
        }

    }
}