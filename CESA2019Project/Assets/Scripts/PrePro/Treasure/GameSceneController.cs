using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneController : SingletonMonoBehaviour<GameSceneController>
{
    [SerializeField] int clearNum = 3;
    int treasureCount = 0;
    [SerializeField] Text text;
    [SerializeField] Text clear;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //  クリア処理
        if(treasureCount==clearNum)
        {
            clear.gameObject.SetActive(true);
        }
        text.text = "☆  " + treasureCount + " / " + clearNum;

    }


    public void GetTreasure()
    {
        treasureCount++;
    }
}
