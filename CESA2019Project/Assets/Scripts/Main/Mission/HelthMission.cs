//  番場 宥輝
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Mission
{
    /// <summary>
    /// 体力〇％以上のミッション
    /// </summary>
    public class HelthMission : MonoBehaviour,IMission
    {
        float _hp;  //目標残存HP

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
            return _hp <= MissonController.Instance.Player.HP;
        }
    }
}