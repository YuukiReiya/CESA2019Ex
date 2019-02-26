using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraB : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    GameObject m_clampObject;
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
        Clamp();
    
    }
    void Clamp()
    {
        // 画面左下のワールド座標をビューポートから取得
        // Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 min = new Vector2(-2,-2);

        // 画面右上のワールド座標をビューポートから取得
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        max = new Vector2(2,2);

        Vector2 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        Debug.Log("min = " + min);
        Debug.Log("max = " + max);


        transform.position = pos;
    }
}
