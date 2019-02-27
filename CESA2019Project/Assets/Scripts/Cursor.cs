using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    bool flg;
    bool flgs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Transform trans = this.transform;
        Vector3 localPos = trans.localPosition;

        if (Input.GetAxis("GamePad0_LJoystick_Y") > 0.5f && !flg )
        {
            flg = true;
            transform.Translate(0, 1.5f, 0);
            if (localPos.y > -0.1f)
            {
                transform.Translate(0, -1.5f, 0);
            }
        }
        else if (Input.GetAxis("GamePad0_LJoystick_Y") < 0.5f)
        {
            flg = false;
        }

        if (Input.GetAxis("GamePad0_LJoystick_Y") < -0.5f && !flgs )
        {
            flgs = true;
            transform.Translate(0, -1.5f, 0);
            if (localPos.y < -122.6f)
            {
                transform.Translate(0, 1.5f, 0);
            }
        }
        else if (Input.GetAxis("GamePad0_LJoystick_Y") > -0.5f)
        {
            flgs = false;
        }

    }
}
