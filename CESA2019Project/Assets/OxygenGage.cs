using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Player;


public class OxygenGage : MonoBehaviour
{
    PlayerController _playerController;
    Slider _slider;

    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
