using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;

public class EcoItem : Game.Item.IItem
{
    float _ecoOxygen = 10f;

    // Start is called before the first frame update
    protected override void GetItemSelf(PlayerController player)
    {

        //StartCoroutine(TimeOver);
    }

    private IEnumerator TimeOver(PlayerController player)
    {
        
        yield return null;
    }
}
