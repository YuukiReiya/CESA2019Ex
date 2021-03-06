﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInput;

namespace Game.Treasure
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

            //  ゲームオーバー または ゲームクリアのため処理しない
            if (Scene.GameSceneController.Instance._state != Scene.GameSceneController.State.PLAY)
            {
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
                    Game.Scene.GameSceneController.Instance.GetTreasure();
                }
            }
            catch
            {

            }


        }

    }
}
