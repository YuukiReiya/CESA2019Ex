//製作者
//伊藤陸人
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInput;

namespace Game.Pleyer
{
    public class PlayerController : MonoBehaviour
    {
        public int Teasure { get; private set; }//探索物の保持数
        public float Oxygen { get; private set; }//酸素

        
        //変数
        [SerializeField] float _angle;//回転値
        [SerializeField] float _jetSpeed;//惑星間の移動スピード
       
        private Vector3 _targetPos;//回転の中心をとるために使う変数

        // Use this for initialization
        void Start()
        {
            //targetに、"Star"タグのオブジェクトのコンポーネントを見つけてアクセスする
            Transform target = GameObject.FindWithTag("Star").transform;
            //変数targetPosにSampleの位置情報を取得
            _targetPos = target.position;
        }

        void Update()
        {
            //ゲームパッド左スティックxの値をとる
            _angle = MyInputManager.AllController.LStick.x;

            //Starを中心に自分を左スティックの倒した分だけ回転
            Vector3 _axis = transform.TransformDirection(new Vector3(0, 0, 1));
            transform.RotateAround(_targetPos, _axis, _angle * Time.deltaTime * -100);
            
            //体の向きの変更
            Vector3 _scale = transform.localScale;

            if (_angle > 0)
            {
                //右方向に移動中に右向き
                _scale.x = 1;
            }
            else if (_angle < 0)
            {
                //左方向に移動中に左向き
                _scale.x = -1;
            }
            transform.localScale = _scale;

        }

        public void JetTrasnsform()
        {
            Vector2 _fromPlanet = this.transform.position;
            
            Vector2 _toPlanet = transform.position;
        }

       
    }

}
