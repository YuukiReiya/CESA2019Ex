/// <summary>
/// 番場 宥輝
/// </summary>
using System.Collections;
using System.Collections.Generic;
using Game.Player;
using UnityEngine;

/// <summary>
/// HPゲージの拡張
/// </summary>
namespace Game.Item
{
    public class ExpantionTunk : IItem
    {
        [SerializeField] float addValue = 10;

        protected override void GetItemSelf(PlayerController player)
        {
            base.GetItemSelf(player);

            player.OxygenLimtesOver(addValue);
            Destroy(this.gameObject);
        }
    }
}