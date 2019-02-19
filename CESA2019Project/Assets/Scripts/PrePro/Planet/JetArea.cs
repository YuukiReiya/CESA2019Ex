using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrePro.Planet
{
    public class JetArea : MonoBehaviour
    {
        //  レイヤー
        const int PLAYER_LAYER = 9;
        const int JETAREA_LAYER = 10;

        //移動先のエリア
        public GameObject nextArea;

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
                //Player以外のレイヤーの当たり判定をとらない
                return;
            }


            //  エラー検知
            try
            {
                //  接触したのはプレイヤーなのでGetComponentで取得
                Player.PlayerController player = collision.GetComponent<Player.PlayerController>();
            }
            catch
            {

            }
        }
    }
}