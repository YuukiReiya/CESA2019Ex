﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;

namespace Game.Camera
{
    public class CameraController : SingletonMonoBehaviour<CameraController>
    {
        [SerializeField] UnityEngine.Camera camera;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Move(GameObject target,float time)
        {
            IEnumerator routine = MoveToTarget(target.transform.position, time);
            StartCoroutine(routine);
        }

        IEnumerator MoveToTarget(Vector3 to,float time)
        {
            //  移動元
            Vector3 from = camera.transform.position;

            //  開始時間
            float startTime = Time.timeSinceLevelLoad;

            //  ループ
            while(from!=to)
            {
                //  経過時間
                float diff = Time.timeSinceLevelLoad - startTime;

                //  移動終了
                if (diff > time)
                {
                    this.transform.position = to;
                    break;
                }

                //  経過時間の割合
                //  開始時間を0，終了時間を1に正規化したときの経過時間の割合から座標を算出
                float rate = diff / time;

                //  座標
                transform.position = Vector3.Lerp(from, to, rate);
                yield return null;
            }
        }

    }
}