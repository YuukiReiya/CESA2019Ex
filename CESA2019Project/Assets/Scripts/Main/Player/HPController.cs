/// <summary>
/// 番場 宥輝
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Pleyer
{
    /// <summary>
    /// HPのコントローラー
    /// </summary>
    public class HPController : MonoBehaviour
    {
        [SerializeField] Slider _UI;
        [SerializeField, Range(0.01f, 1)] float _interval = 0.5f;
        [SerializeField] float offset;
        [SerializeField] RectTransform _backGround;
        [SerializeField] RectTransform _fillArea;
        float _hp;
        const float BASE_HP = 100;  // 基準となるHP

        void Reset()
        {
            _UI = GetComponent<Slider>();
            var childs = this.GetComponentsInChildren<RectTransform>();
            _backGround = childs[1];
            _fillArea   = childs[2];
        }

        // Start is called before the first frame update
        void Start()
        {
            _UI.maxValue = BASE_HP;
            _hp = _UI.value; 
        }

        // Update is called once per frame
        void Update()
        {
            //  HPの更新(線形補完)
            float hp = _UI.value;
            _UI.value = Mathf.Lerp(_UI.value, _hp, _interval);
        }

        /// <summary>
        /// HP回復
        /// </summary>
        /// <param name="point">回復量(0 ～ 100)</param>
        public void Heal(uint point)
        {
            _hp = _UI.maxValue < (_hp + point) ? _UI.maxValue : _hp + point;
        }

        /// <summary>
        /// ダメージ
        /// </summary>
        /// <param name="point">ダメージ量(0 ～ 100)</param>
        public void Damage(uint point)
        {
            _hp = _UI.minValue > (_hp - point) ? _UI.minValue : _hp - point;
        }

        /// <summary>
        /// HPの書き換え
        /// </summary>
        /// <param name="hp"></param>
        public void Overwrite(uint hp)
        {
            _hp = hp;
        }

        /// <summary>
        /// 上限値の変更
        /// </summary>
        /// <param name="value"></param>
        public void AddMaxValue(float value)
        {
            _UI.maxValue += value;

            //  valueの範囲(0～100)を100で除算し割合を求める
            float rate = value / BASE_HP;
            Vector3 scale = _backGround.localScale;
            scale.x += rate;

            //  ゲージの長さ変更
            _backGround.localScale = scale;
            _fillArea.localScale = scale;

            //  上昇分の回復
            Heal((uint)value);
        }

        /// <summary>
        /// 符号なし整数型からfloat型(0～1に値を丸める)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        float CastToFloat(uint value)
        {
            float ret = value;
            return ret;
        }
    }
}