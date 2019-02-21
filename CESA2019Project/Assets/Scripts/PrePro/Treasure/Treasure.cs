﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrePro.Treasure
{
    public class Treasure : MonoBehaviour
    {
        //  レイヤー
        const int PLAYER_LAYER = 9;


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
                    GameSceneController.Instance.GetTreasure();
                }
            }
            catch
            {
            }


        }

    }
}
