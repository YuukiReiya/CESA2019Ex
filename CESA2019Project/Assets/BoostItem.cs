///<summary>
///伊藤　陸人
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;

public class BoostItem : Game.Item.IItem
{
    [SerializeField] float _upJetSpeed = 100f;
    [SerializeField] int _time = 10;
    protected override void GetItemSelf(PlayerController player)
    {

        //スピードアップ
        //player.AddSpeed(_upJetSpeed);
        player.StartCoroutine(Timeover(player));

        Debug.Log("ブースト！");
        //オブジェクトを削除
        Destroy(gameObject);
    }

    private IEnumerator Timeover(PlayerController player)
    {
        player.AddSpeed(_upJetSpeed);
        for (int i = 0; i < _time*60; i++)
        {
        Debug.Log("減速");
        yield return null;

        }
        player.AddSpeed(-_upJetSpeed);
        Debug.Log("減速");

    }
}
