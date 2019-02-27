using System.Collections;
using System.Collections.Generic;
using Game.Player;
using UnityEngine;

namespace Game.Item
{
    public class StunBomb : IItem
    {
        protected override void GetItem()
        {
            base.GetItem();

            Game.Enemy.EnemyController.Instance.Stun();
        }

    }
}
