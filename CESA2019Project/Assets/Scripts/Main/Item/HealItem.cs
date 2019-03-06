///<summary>
///伊藤 陸人
///</summary>
using System.Collections;
using System.Collections.Generic;
using Game.Player;
using UnityEngine;

namespace Game.Item
{
    public class HealItem : Game.Item.IItem
    {
        float _healOxygen = 30;//酸素の回復値

        protected override void GetItemSelf(PlayerController player)
        {
            base.GetItemSelf(player);

            //酸素を回復
            player.AddOxygen(_healOxygen);


            
            //オブジェクトの削除
            Destroy(this.gameObject);
        }



    }
}
