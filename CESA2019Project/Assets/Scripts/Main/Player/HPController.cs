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
        [SerializeField, Range(0.01f, 1)] float _interval = 0.01f;
        float _hp;

        void Reset()
        {
        }

        // Start is called before the first frame update
        void Start()
        {
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
        /// 
        /// </summary>
        /// <param name="hp"></param>
        public void Overwrite(uint hp)
        {
            _hp = hp;
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