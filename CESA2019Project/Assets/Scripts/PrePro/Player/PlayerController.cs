using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


namespace PrePro.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Sprite[] idle;
        [SerializeField] Sprite[] run;
        [SerializeField] Image guge;
        [SerializeField] GameObject target;
        [SerializeField] float moveSpeed = 100;
        [SerializeField] float jetSpeed = 5;
        [SerializeField] AnimationCurve curve;
        [SerializeField] float time = 2;
        private IEnumerator routine;

        float rate;

        // Start is called before the first frame update
        void Start()
        {
            rate = 1;
        }

        // Update is called once per frame
        void Update()
        {
            if (routine == null)
            {
                Move();
            }
            guge.fillAmount = rate;
        }

        private void Move()
        {
            Vector3 axis = this.transform.TransformDirection(new Vector3(0, 0, 1));
            float input = -MyInputManager.AllController.LStick.x;
            this.transform.RotateAround(target.transform.position, axis, input * moveSpeed * Time.deltaTime);
        }

        public void JetAction(GameObject toArea,GameObject target)
        {
            //  早期リターン
            if (!MyInputManager.AllController.A) { return; }
            if(routine != null) { return; }

            //  メソッド呼び出し
            routine = InterplanetaryMovement(
                toArea,
                () =>
            {
                routine = null;
                this.target = target;
            }
            );
            rate -= 0.15f;
            StartCoroutine(routine);
            StartCoroutine(GageFall(time, rate));
        }

        //  惑星間移動
        private IEnumerator InterplanetaryMovement(GameObject toArea, Action action = null)
        {
            //  移動元
            Vector2 from = this.transform.position;

            //  移動先
            Vector2 to = toArea.transform.position;

            //  回転
            float rot = this.transform.rotation.eulerAngles.z;
            float rot_ = rot + 180;


            //  開始時間
            float startTime = Time.timeSinceLevelLoad;

            //  ループ
            while (from != to)
            {
                //  経過時間
                float diff = Time.timeSinceLevelLoad - startTime;

                //  現在の回転値(オイラー)
                Vector3 euler = this.transform.rotation.eulerAngles;

                //  移動終了 & 回転終了
                if (diff > time)
                {
                    this.transform.position = to;
                    euler.z = rot_;
                    this.transform.rotation = Quaternion.Euler(euler);
                    break;
                }
                
                //  経過時間の割合
                //  開始時間を0，終了時間を1に正規化したときの経過時間の割合から座標を算出
                float rate = diff / time;

                //  座標
                transform.position = Vector2.Lerp(from, to, curve.Evaluate(rate));

                //  回転
                euler.z = Mathf.Lerp(rot, rot_, curve.Evaluate(rate));
                transform.rotation = Quaternion.Euler(euler);
                yield return null;
            }

            //  コールバックメソッド実行
            action();
        }


        private IEnumerator GageFall(float time,float fallValue)
        {
            //float tmp = guge.fillAmount;
            //float nokori = guge.fillAmount - fallValue;

            //float startTime = Time.timeSinceLevelLoad;

            guge.fillAmount -= fallValue;
            yield return null;
            //while (guge.fillAmount != nokori)
            //{
            //    float diff = Time.timeSinceLevelLoad - startTime;

            //    if (diff > time)
            //    {
            //        guge.fillAmount = nokori;
            //        break;
            //    }

            //    float rate = diff / time;
            //    Debug.Log("= " + rate);
            //    guge.fillAmount = Mathf.Lerp(0, 1, rate);
            //    yield return null;
            //}
        }
    }
}