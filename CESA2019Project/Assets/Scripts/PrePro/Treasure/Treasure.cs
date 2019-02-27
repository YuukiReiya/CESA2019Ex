using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInput;

namespace PrePro.Treasure
{
    public class Treasure : MonoBehaviour
    {
        //  レイヤー
        const int PLAYER_LAYER = 9;
       [SerializeField] bool isFake;

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
                //  宝箱取得
                if (MyInputManager.AllController.B)
                {
                    Destroy(this.gameObject);
                    if(!isFake)
                    GameSceneController.Instance.GetTreasure();
                }
            }
            catch
            {

            }


        }

    }
}
