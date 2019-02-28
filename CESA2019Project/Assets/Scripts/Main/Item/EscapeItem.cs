/// <summary>
/// 番場 宥輝
/// </summary>
using System.Collections;
using System.Collections.Generic;
using Game.Player;
using UnityEngine;

/// <summary>
/// とったら任意の場所に瞬間移動するアイテム
/// (一番最初の場所に設定することでエスケープアイテムとして機能させる)
/// </summary>
namespace Game.Item
{
    public class EscapeItem : IItem
    {
        [SerializeField] Vector3 escapePos;

        private void Reset()
        {
            escapePos =FindObjectOfType<PlayerController>().transform.position;

        }

        protected override void GetItemSelf(PlayerController player)
        {
            base.GetItemSelf(player);

            //  プレイヤーの位置を設定座標へ
            player.gameObject.transform.position = escapePos;

            Destroy(this.gameObject);
        }
    }
}