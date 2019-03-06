using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInput;

namespace Game.Planet
{
    public class JetArea : MonoBehaviour
    {
        //  レイヤー
        const int PLAYER_LAYER = 9;
        const int JETAREA_LAYER = 10;

        //移動先のエリア
        public GameObject nextArea;

        //移動先の惑星オブジェクト
        public GameObject nextPlanet;

        // 移動先のカメラ位置
        public GameObject nextCameraPos;

        //  移動先到着後の回転値
        [SerializeField] float rot;
        
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        //  プレイヤーがJetAreaに触れているときにボタン入力がされたときにPlayerのアクションを呼び出す
        private void OnTriggerStay2D(Collider2D collision)
        {
            //  レイヤーの当たり判定
            if (PLAYER_LAYER != collision.gameObject.layer)
            {
                // Player以外のレイヤーの当たり判定をとらない
                return;
            }

            Player.PlayerController player = null;
            //  エラー検知
            try
            {
                //  接触したのはプレイヤーなのでGetComponentで取得
                player = collision.GetComponent<Player.PlayerController>();
                player.JetAction(nextArea, nextPlanet, rot);
            }
            catch
            {
                //  例外処理
                Debug.LogError("PlayerContrllerのGetComponentで例外発生");
            }

            //  カメラの移動先が設定されていれば移動させる
            if (!nextCameraPos) { return; }
            Camera.CameraController.Instance.Move(nextCameraPos, player.GetJetTime());
        }
    }
}