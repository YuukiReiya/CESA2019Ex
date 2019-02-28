/// <summary>
/// 番場 宥輝
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;//プリプロ後にGame.Playerに変更

/// <summary>
/// アイテムの基底クラス
/// </summary>
namespace Game.Item
{
    public abstract class IItem : MonoBehaviour
    {
        //  プレイヤーのレイヤー
        const int PLAYER_LAYER = 9;


        /// <summary>
        /// アイテムを取得したときに得られるアイテム効果
        /// (処理を書いてください)
        /// </summary>
        protected virtual void GetItemSelf(Game.Player.PlayerController player)
        {

        }

        /// <summary>
        /// アイテムを取得したときに得られるアイテム効果
        /// (アイテムの処理を書いてください)
        /// プレイヤーを必要としない敵のスタンetcはこちら
        /// </summary>
        protected virtual void GetItem()
        {

        }

        /// <summary>
        /// アイテムの取得
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerStay2D(Collider2D collision)
        {
            //  プレイヤーのレイヤー以外無視する
            if (PLAYER_LAYER != collision.gameObject.layer)
            {
                return;
            }

            //  アイテム取得のための入力がされていない場合処理しない
            if (!MyInput.MyInputManager.AllController.B)
            {
                return;
            }

            //  ゲームオーバー または ゲームクリアのため処理しない
            if (Scene.GameSceneController.Instance._state != Scene.GameSceneController.State.PLAY)
            {
                return;
            }

            //  Playerを必要としないアイテム
            GetItem();

            //  エラー検知
            PlayerController player = null;
            try
            {
                player = collision.gameObject.GetComponent<PlayerController>();
            }
            //  例外処理
            catch
            {
                Debug.Log("playerに例外発生");
            }

            //  自身に効果があるもの
            GetItemSelf(player);
        }

    }
}