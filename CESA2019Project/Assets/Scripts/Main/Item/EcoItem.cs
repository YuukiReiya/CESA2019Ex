using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;

public class EcoItem : Game.Item.IItem
{
    [SerializeField]float _ecoOxygen = 5f;
    [SerializeField]float _time = 0;
    [SerializeField] PlayerController player;
    // Start is called before the first frame update

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void Update()
    {
        _time += Time.deltaTime;


        if (player._jet == _ecoOxygen)
        {
            //5秒後に値を戻す
            if (_time >= 5.0f)
            {
                func();
            }

        }
            
        
        
        
    }
    protected override void GetItemSelf(PlayerController player)
    {
        //酸素消費減
        //StartCoroutine(TimeOver(player));
        player._jet = _ecoOxygen;
        Destroy(this.gameObject);

        
    }

    //private IEnumerator TimeOver(PlayerController player)
    //{
    //    player._jet = _ecoOxygen;
    //    for (int i = 0; i < _time * 60; i++)
    //    {
    //        yield return null;
    //    }
    //}
    private void func()
    {
        player._jet = 10f;
    }
}
