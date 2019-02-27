using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Framework;
using UnityEngine.SceneManagement;

namespace Game.Scene
{
    public class GameSceneController : SingletonMonoBehaviour<GameSceneController>
    {
        [SerializeField] int clearNum = 3;
        int treasureCount = 0;
        [SerializeField] Text text;
        [SerializeField] Text clear;
        [SerializeField] PrePro.Player.PlayerController _player;

        public enum State
        {
            CLEAR,
            PLAY,
            GAME_OVER
        }
        public State _state { get; private set; }

        private void Reset()
        {
            _player = FindObjectOfType<PrePro.Player.PlayerController>();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //  クリア処理
            if (treasureCount == clearNum)
            {
                _state = State.CLEAR;
                clear.gameObject.SetActive(true);
            }

            //  ゲームオーバー処理
            //else if(_player.)
            {
                
            }
            text.text = "☆  " + treasureCount + " / " + clearNum;

            //  ゲームオーバー & ゲームクリア処理
            if (_state != State.PLAY)
            {
                //  A:タイトル遷移

                //  B:リトライ
                if(MyInput.MyInputManager.AllController.B)
                {
                    //  シーンの再読み込み
                    SceneManager.LoadScene(0);
                }
            }

        }


        public void GetTreasure()
        {
            treasureCount++;
        }

        
    }
}