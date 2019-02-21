using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Pleyer
{
    public class PlayerController : MonoBehaviour
    {


        //変数
        //回転角度
        public float _angle;

        //回転の中心をとるために使う変数
        private Vector3 _targetPos;

        //ゲームパッドの入力を
        //private MyInputManager _gamePade;

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


    }

}
