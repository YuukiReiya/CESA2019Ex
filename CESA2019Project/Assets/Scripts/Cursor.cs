using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInput;

public class Cursor : MonoBehaviour
{
    bool flg;
    bool flgs;

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
        if (MyInputManager.AllController.A && localPos.y < -122.6f)
        {
       #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
		Application.OpenURL("http://www.yahoo.co.jp/");
       #else
		Application.Quit();
      #endif
        }
    }
}
