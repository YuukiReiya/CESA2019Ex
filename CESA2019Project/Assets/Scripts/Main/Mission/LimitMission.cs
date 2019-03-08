//  番場 宥輝
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Mission
{

    /// <summary>
    /// 移動回数の〇回数以内を目指すミッション
    /// </summary>
    public class LimitMission : MonoBehaviour, IMission
    {
        [SerializeField] int _num;  //  目標撃破数

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        bool IMission.Achievement()
        {
            return MissonController.Instance.Player.GetJetCount() <= _num;
        }
    }
}