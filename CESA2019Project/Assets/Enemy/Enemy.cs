using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //変数
    //一秒当たりの回転角度
    public float _angle = 30f;
    int x = 1;
    public GameObject PartclePrefabs;

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

        x = 0;

    }

    // Update is called once per frame
    void Update()
    {

        //	Sampleを中心に自分を現在の上方向に、毎秒angle分だけ回転する。
        Vector3 axis = transform.TransformDirection(new Vector3(0, 0, 1));
        transform.RotateAround(target.transform.position, axis, _angle * x * Time.deltaTime);

        //敵が攻撃されたとき
        //if ()
        {
           // Destroy(this.gameObject);
           // Debug.Log("死亡");
        }
        //else　if()
        {
            //敵から攻撃をくらったとき

           // Debug.Log("ゲージ消費");
        }

    }
}