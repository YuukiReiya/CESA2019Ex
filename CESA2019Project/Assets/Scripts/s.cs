using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class s : Framework.SingletonMonoBehaviour<s>
{
    [SerializeField] int index = 0;
    PrePro.Pleyer.HPController h;

    // Start is called before the first frame update
     void Start()
    {
        h = GameObject.FindObjectOfType<PrePro.Pleyer.HPController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            h.Damage(10);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            h.Heal(10);
        }
    }
}
