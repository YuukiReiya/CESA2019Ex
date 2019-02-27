using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject Gemeover;
    [SerializeField] int _item;
    // Start is called before the first frame update
    void Start()
    {
        Gemeover.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Gemeover.SetActive(true);
        }
    }
}
