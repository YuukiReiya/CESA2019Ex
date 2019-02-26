using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraB : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    void Start()
    {
       // 自分のRigidbodyを取ってくる
       m_Rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        // Rスティックでカメラを動かす
        var pos = transform.position;
        //Debug.Log(Input.GetAxis("Horizontal"));
        if(Input.GetAxis("GamePad0_RJoystick_X") > 0.5f)
        {
            pos.x += 10*Time.deltaTime;
            transform.position = pos;
            //transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f));
        }
        if (Input.GetAxis("GamePad0_RJoystick_X") < 0)
        {
            pos.x -= 10 * Time.deltaTime;
            transform.position = pos;
            // transform.Rotate(new Vector3(0.0f, -1.0f, 0.0f));
        }
        if (Input.GetAxis("GamePad0_RJoystick_Y") >0.5f)
        {
            pos.y += 10 * Time.deltaTime;
            transform.position = pos;
            //transform.Rotate(new Vector3(1.0f, 0.0f, 0.0f));
        }
        if (Input.GetAxis("GamePad0_RJoystick_Y") < 0)
        {
            pos.y -= 10 * Time.deltaTime;
            transform.position = pos;
            // transform.Rotate(new Vector3(-1.0f, 0.0f, 0.0f));
        }
    }
   
}
