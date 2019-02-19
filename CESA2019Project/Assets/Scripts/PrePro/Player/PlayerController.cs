using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PrePro.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Sprite[] idle;
        [SerializeField] Sprite[] run;

        [SerializeField] GameObject target;
        [SerializeField] float moveSpeed = 10;
        private IEnumerator routine;
        private float jetSpeed;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector3 axis = this.transform.TransformDirection(new Vector3(0, 0, 1));
            float input = -MyInputManager.AllController.LStick.x;
            this.transform.RotateAround(target.transform.position, axis, input * moveSpeed * Time.deltaTime);
        }

        public void JetAction(GameObject toArea)
        {
            routine = InterplanetaryMovement(
                toArea,
                () =>
            {
                routine = null;
            }
            );
            StartCoroutine(routine);
        }

        private IEnumerator InterplanetaryMovement(GameObject toArea, Action action = null)
        {
            Vector3 from = this.transform.position;
            Vector3 to = toArea.transform.position;
            while (from != to)
            {
                Vector3 pos = Vector3.Lerp(from, to, jetSpeed);
                this.transform.position = pos;
                yield return null;
            }

            //  コールバックメソッド実行
            if(action!=null)
            {
                action();
            }
        }
    }
}