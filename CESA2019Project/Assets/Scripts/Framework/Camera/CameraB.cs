using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  namespaceで分けてください！ 番場より
namespace Game.Camera
{
    public class CameraB : MonoBehaviour
    {
        Rigidbody m_Rigidbody;

        //---------------------------------------------------------
        //  番場 編集
        [SerializeField] Vector2 _minRect;
        [SerializeField] Vector2 _maxRect;
        //---------------------------------------------------------

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
            if (Input.GetAxis("GamePad0_RJoystick_X") > 0.5f)
            {
                pos.x += 10 * Time.deltaTime;
                //transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f));
            }
            if (Input.GetAxis("GamePad0_RJoystick_X") < 0)
            {
                pos.x -= 10 * Time.deltaTime;
                // transform.Rotate(new Vector3(0.0f, -1.0f, 0.0f));
            }
            if (Input.GetAxis("GamePad0_RJoystick_Y") > 0.5f)
            {
                pos.y += 10 * Time.deltaTime;
                //transform.Rotate(new Vector3(1.0f, 0.0f, 0.0f));
            }
            if (Input.GetAxis("GamePad0_RJoystick_Y") < 0)
            {
                pos.y -= 10 * Time.deltaTime;
                // transform.Rotate(new Vector3(-1.0f, 0.0f, 0.0f));
            }

            //---------------------------------------------------------
            //  番場 編集
            pos.x = Mathf.Clamp(pos.x, _minRect.x, _maxRect.x);
            pos.y = Mathf.Clamp(pos.y, _minRect.y, _maxRect.y);
            this.transform.position = pos;
            //---------------------------------------------------------
        }

    }
}
