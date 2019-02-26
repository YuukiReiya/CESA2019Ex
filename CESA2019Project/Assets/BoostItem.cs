//<summary>
//伊藤　陸人
//</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrePro.Player;

public class BoostItem : Game.Item.IItem
{
    [SerializeField] float _upJetSpeed = 100f;
    
    protected override void GetItemSelf(PlayerController player)
    {
       
        //スピードアップ
        player.AddSpeed(_upJetSpeed);

        Debug.Log("ブースト！");
        //オブジェクトを削除
        Destroy(gameObject);
    }
}
