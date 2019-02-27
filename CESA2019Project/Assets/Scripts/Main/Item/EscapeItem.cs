﻿using System.Collections;
using System.Collections.Generic;
using PrePro.Player;
using UnityEngine;

namespace PrePro.Item
{
    public class Escape : IItem
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

        }
    }
}