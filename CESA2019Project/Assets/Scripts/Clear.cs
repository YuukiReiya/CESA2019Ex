using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{

   [SerializeField] GameObject cleard;
    [SerializeField] GameObject cleards;
    void Start()
    {
        cleard.SetActive(false);
        cleards.SetActive(false);
    }

    public void clear()
    {
           cleard.SetActive(true);
           cleards.SetActive(true);
    }
}
