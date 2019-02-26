using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Transform trans = this.transform;
        Vector3 localPos = trans.localPosition;
        if (Input.GetAxis("GamePad0_LJoystick_Y") > 0.5f)
        {
        Debug.Log("sss");
            localPos.x = 0.0f;
            localPos.y -= 5.0f;
            localPos.z = 0.0f;
        }

    }
}
