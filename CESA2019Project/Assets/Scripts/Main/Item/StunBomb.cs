/// <summary>
/// 番場 宥輝
/// </summary>
using System.Collections;
using System.Collections.Generic;
using Game.Player;
using UnityEngine;

/// <summary>
/// 敵全体をスタンさせる
/// (敵のスタン時間は各Enemyで設定)
/// </summary>
namespace Game.Item
{
    public class StunBomb : IItem
    {
        protected override void GetItem()
        {
            base.GetItem();

            Game.Enemy.EnemyController.Instance.Stun();
            Destroy(this.gameObject);
        }

    }
}
