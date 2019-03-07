using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{

   [SerializeField] GameObject cleard;
    [SerializeField] GameObject cleards;
    // Start is called before the first frame update
    void Start()
    {
        cleard.SetActive(false);
        cleards.SetActive(false);
    }
    void Update() {
        if (Input.GetKey(KeyCode.Space))
        {
            cleard.SetActive(true);
            cleards.SetActive(true);
        } 
    }
}
