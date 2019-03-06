///<summary>
///伊藤　陸人
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;

namespace Game.Item
{
    public class BoostItem : Game.Item.IItem
{
    [SerializeField] float _upJetSpeed = 50f;
    [SerializeField] int _time = 10;
    protected override void GetItemSelf(PlayerController player)
    {

        //スピードアップ
        player.StartCoroutine(TimeOver(player));

        
        //オブジェクトを削除
        Destroy(this.gameObject);
    }

    private IEnumerator TimeOver(PlayerController player)
    {
        player.AddSpeed(_upJetSpeed);
        for (int i = 0; i < _time*60; i++)
        {
        
        yield return null;

        }
        player.AddSpeed(-_upJetSpeed);
        

    }
}


}
