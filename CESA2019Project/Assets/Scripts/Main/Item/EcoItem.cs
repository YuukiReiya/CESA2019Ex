using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;

public class EcoItem : Game.Item.IItem
{
    [SerializeField]float _ecoOxygen = 5f;
    [SerializeField] int _time;
    // Start is called before the first frame update
    protected override void GetItemSelf(PlayerController player)
    {
        //酸素消費減
        StartCoroutine(TimeOver(player));
        
        Destroy(this.gameObject);
    }

    private IEnumerator TimeOver(PlayerController player)
    {
        player._jet = _ecoOxygen;
        yield return new WaitForSeconds(_time);

        player._jet = 10f;
        
    }
}
