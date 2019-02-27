using System.Collections;
using System.Collections.Generic;
using PrePro.Player;
using UnityEngine;

namespace PrePro.Item
{
    public class StunBomb : IItem
    {
        protected override void GetItem()
        {
            base.GetItem();

            PrePro.Enemy.EnemyController.Instance.Stun();
        }

    }
}
