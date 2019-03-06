using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;

public class EcoItem : Game.Item.IItem
{
    [SerializeField]float _ecoOxygen = 10f;
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
        player._damage = 10f;
        yield return new WaitForSeconds(_time);

        player._damage = 20f;
        yield return null;
    }
}
