using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using MyInput;
using Framework.Sound;

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
        public GameObject target;//移動中心のオブジェクト
        [SerializeField] AnimationCurve curve;
        [SerializeField] float _time = 1;
        private IEnumerator routine;
        private Game.Pleyer.HPController _hpc;
        float rate;

        [SerializeField] Status _status;

        [SerializeField] float _frame;

        [System.NonSerialized] public bool isAttack;//攻撃フラグをにする
        bool _isMove;
        float _directionMove;//Playerの方向とる
        float _directionRight;//RB
        float _directionLeft;//LB
        float _directionButton;//LB、RBでPlayerの方向をとる
        float _directionAttack;//攻撃の方向

        int _jetCount;//惑星間の移動回数

        public float _damage;//ダメ―ジ量
        public float _attack;//攻撃消費量
        public float _jet;//惑星間移動の消費量

        public float HP { get { return _status.oxygen; } }
        public float JetTime { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            _isMove = false;
            isAttack = false; 
            rate = 1;
            _status.speed = 100;
            _status.oxygen = 100;
            _hpc = FindObjectOfType<Game.Pleyer.HPController>();

            _directionMove = -1;
            _directionRight = -1;
            _directionLeft = 1;
            _directionButton = 0;
            _directionAttack = -1;
            
            _jetCount = 0;
            JetTime = 1;

            _damage = 20f;
            _attack = 10f;
            _jet = 10f;
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
            if (MyInputManager.AllController.X
                && !_isMove)
            {
               //攻撃
               Attack();
            }
            
        }
        public void OxygenLimtesOver(float value)
        {
            _hpc.AddMaxValue(value);
        }

        private void Move()
        {
            Vector3 _axis = this.transform.TransformDirection(new Vector3(0, 0, 1));


            //Lステックで移動
            float _input = MyInputManager.AllController.LStick.x;

            //--LR移動-------------------------------------------------------------------------------------------------------------
            //移動をRB,LB
            //RBで右回転
            bool _inputRB = MyInputManager.AllController.RT_Hold;
            //LBで左回転
            bool _inputLB = MyInputManager.AllController.LT_Hold;
            if (_inputRB)
            {
                _directionButton = _directionRight;
                _directionAttack = _directionRight;

                //  効果音
                SoundManager.Instance.PlayOnSE("Run");
            }
            else if (_inputLB)
            {
                _directionButton = _directionLeft;
                _directionAttack = _directionLeft;

                //  効果音
                SoundManager.Instance.PlayOnSE("Run");
            }
            else
            {
                _directionButton = 0;
            }
            
            //LR
            this.transform.RotateAround(target.transform.position, _axis, _status.speed * Time.deltaTime * _directionButton);
            //----------------------------------------------------------------------------------------------------------------

            



            if (_input > 0 )
            {
                _directionMove = -1;
            }
            else if (_input < 0)
            {
                _directionMove = 1;
            }
            //ステック
            this.transform.RotateAround(target.transform.position, _axis, Mathf.Abs(_input) * _status.speed * Time.deltaTime * _directionMove);
           
        }



        //攻撃関数
        private void Attack()
        {
            
            DamageOxygen(_attack);
            StartCoroutine("AttackMove");
        }

        //攻撃のコルーチン
        private IEnumerator AttackMove()
        {
            
            Vector3 _axis = this.transform.TransformDirection(new Vector3(0, 0, 1));
            
            for (int i = 0; i < _frame; i++)
            {

                isAttack = true;
                
                transform.RotateAround(target.transform.position, _axis, _status.attack  * Time.deltaTime * i * _directionAttack);
                yield return null;
            }

            isAttack = false;
            
        }



        public void JetAction(GameObject toArea, GameObject target ,float rot)
    
        {
            
            //  早期リターン
            if (!MyInputManager.AllController.A) { return; }
            if (routine != null) { return; }

            _isMove = true;

            //  メソッド呼び出し
            routine = InterplanetaryMovement(
                toArea,rot,
                () =>
            {
                routine = null;
                this.target = target;
                _isMove = false;
            }
            );
            rate -= 0.15f;
            StartCoroutine(routine);

            //if ()
            //{
            //    DamageOxygen(10);
            //}
            //else if ()
            //{
                DamageOxygen(_jet);
            //}
            


        }

        //  惑星間移動
        private IEnumerator InterplanetaryMovement(GameObject toArea, float toRot,Action action = null)
        {
            //  移動元
            Vector2 from = this.transform.position;

            //  移動先
            Vector2 to = toArea.transform.position;

            //  回転
            float fromRot = this.transform.rotation.eulerAngles.z;//回転元
            
            

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
                    euler.z = toRot;
                    this.transform.rotation = Quaternion.Euler(euler);
                    break;
                }

                //  経過時間の割合
                //  開始時間を0，終了時間を1に正規化したときの経過時間の割合から座標を算出
                float rate = diff / _time;


                //  座標
                transform.position = Vector2.Lerp(from, to, curve.Evaluate(rate));

                //  回転
                euler.z = Mathf.Lerp(fromRot, toRot, curve.Evaluate(rate));
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
        
        //惑星間移動回数のカウント
        public int GetJetCount()
        {
            return _jetCount;
        }

        public void SlowSpeed(float slow)
        {
            _status.speed = slow;
        }
        //
        //public void EcoOxygen(float eco)
        //{
        //    _jet = eco;
        //}
    }
}