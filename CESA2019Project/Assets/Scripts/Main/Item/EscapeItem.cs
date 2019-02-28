/// <summary>
/// 番場 宥輝
/// </summary>
using System.Collections;
using System.Collections.Generic;
using Game.Player;
using UnityEngine;

/// <summary>
/// 初期位置の場所に瞬間移動するアイテム
/// </summary>
namespace Game.Item
{
    public class EscapeItem : IItem
    {
        GameObject target;
        Vector3 pos;
        Quaternion rot;
        Vector3 scale;


        private void Reset()
        {

        }

        private void Start()
        {
            PlayerController player = FindObjectOfType<PlayerController>();
            target = player.target;
            pos = player.transform.position;
            rot = player.transform.rotation;
            scale = player.transform.localScale;
        }


        protected override void GetItemSelf(PlayerController player)
        {
            base.GetItemSelf(player);

            //  プレイヤーの位置を設定座標へ
            player.transform.position = pos;
            player.transform.rotation = rot;
            player.transform.localScale = scale;
            player.target = target;
            Destroy(this.gameObject);
        }
    }
}