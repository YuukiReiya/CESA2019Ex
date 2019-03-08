//  番場 宥輝
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Mission
{

    /// <summary>
    /// ミッションコントローラー
    /// </summary>
    public class MissonController : Framework.SingletonMonoBehaviour<MissonController>
    {
        [SerializeField] IMission _mission;
        [SerializeField] Player.PlayerController _player;
        public Player.PlayerController Player { get { return _player; } }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
        }

        void Judge()
        {
            if(_mission.Achievement())
            {

            }
        }
    }
}