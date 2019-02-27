using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using MyInput;


namespace Game.Player
{
    public class PlayerController : MonoBehaviour
    {

        [System.Serializable]
        public struct Status {
            public float speed;//移動ステータス
            public float attack;//攻撃ステータス
            public float oxygen;//酸素ステータス
        }

        [SerializeField] Sprite[] idle;
        [SerializeField] Sprite[] run;
        [SerializeField] GameObject target;//移動中心のオブジェクト
        [SerializeField] AnimationCurve curve;
        [SerializeField] float _time = 1;
        private IEnumerator routine;
        private Game.Pleyer.HPController _hpc;
        float rate;

        [SerializeField] Status _status;

        [SerializeField] float _frame;

        [System.NonSerialized] public bool isAttack;//攻撃フラグをにする
        float _dre;//Playerの方向とる

        public float HP { get { return _status.oxygen; } }
        

        // Start is called before the first frame update
        void Start()
        {
            isAttack = false; 
            rate = 1;
            _status.speed = 100;
            _hpc = FindObjectOfType<Game.Pleyer.HPController>();
            _status.oxygen = 100;

            _dre = -1;


        }

        // Update is called once per frame
        void Update()
        {
            if (Scene.GameSceneController.Instance._state != Scene.GameSceneController.State.PLAY) { return; }

            if (routine == null)
            {
                Move();
            }
            
            //Xをおしたら？
            if (MyInputManager.AllController.X)
            {
               //攻撃
               Attack();
            }

            //Debug.Log(HP);
        }
        public void OxygenLimtesOver(float value)
        {
            _hpc.AddMaxValue(value);
        }

        private void Move()
        {
            Vector3 _axis = this.transform.TransformDirection(new Vector3(0, 0, 1));
            float _input = MyInputManager.AllController.LStick.x;
            if (_input>0)
            {
                _dre = -1;
            }
            else if (_input<0)
            {
                _dre = 1;
            }
            this.transform.RotateAround(target.transform.position, _axis, Mathf.Abs(_input) * _status.speed * Time.deltaTime*_dre);
        }

        //攻撃関数
        private void Attack()
        {
            _hpc.Damage(10);

            StartCoroutine("AttackMove");
        }

        //攻撃のコルーチン
        private IEnumerator AttackMove()
        {
            Vector3 _axis = this.transform.TransformDirection(new Vector3(0, 0, 1));

            

            for (int i = 0; i < _frame; i++)
            {

                isAttack = true;
                Debug.Log("攻撃");
                transform.RotateAround(target.transform.position, _axis, _status.attack  * Time.deltaTime * i * _dre);
                yield return null;
            }

            isAttack = false;
        }



        public void JetAction(GameObject toArea, GameObject target)
        {
            //  早期リターン
            if (!MyInputManager.AllController.A) { return; }
            if (routine != null) { return; }

            
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
            _hpc.Damage(20);
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
                if (diff > _time)
                {
                    this.transform.position = to;
                    euler.z = rot_;
                    this.transform.rotation = Quaternion.Euler(euler);
                    break;
                }

                //  経過時間の割合
                //  開始時間を0，終了時間を1に正規化したときの経過時間の割合から座標を算出
                float rate = diff / _time;


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

        //スピードUPアイテムの参照
        public void AddSpeed(float _speed)
        {
            _status.speed += _speed;
        }

        //酸素回復アイテムの参照
        public void AddOxygen(float _oxygen)
        {
            _status.oxygen += _oxygen;
            _hpc.Heal((uint)_oxygen);
        }

        //酸素ダメージの参照
        public void DamageOxygen(float oxygen)
        {
            _status.oxygen -= oxygen;
            _hpc.Damage((uint)oxygen);
        }
            
    }
}