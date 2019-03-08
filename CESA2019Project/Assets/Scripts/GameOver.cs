using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject Gameover;
    [SerializeField] GameObject Gameovers;

    void Start()
    {
        Gameover.SetActive(false);
        Gameovers.SetActive(false);
    }
   
    
    public void over()
    {
            Gameover.SetActive(true);
            Gameovers.SetActive(true);
    }
}
