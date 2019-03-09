﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Framework;
using UnityEngine.SceneManagement;
using MethodExpansion;
using Framework.Fade;

namespace Game.Scene
{
    public class GameSceneController : SingletonMonoBehaviour<GameSceneController>
    {
        [SerializeField] int clearNum = 3;
        int treasureCount = 0;
        [SerializeField] Text text;
        [SerializeField] Player.PlayerController _player;
        [SerializeField] GameObject _canvas;
        [SerializeField] GameObject _clearImage;
        [SerializeField] GameObject _gameoverImage;
        [SerializeField] float _fadeFrame = 45;
        bool _isInput = false;

        public enum State
        {
            CLEAR,
            PLAY,
            GAME_OVER
        }
        public State _state { get; private set; }

        private void Reset()
        {
            _player = FindObjectOfType<Player.PlayerController>();
        }

        // Start is called before the first frame update
        void Start()
        {
            _clearImage.SetActive(false);
            _gameoverImage.SetActive(false);
            _state = State.PLAY;
            _isInput = false;
            if (FadeManager.Instance)
            {
                var routine = FadeManager.Instance.FadeOutCoroutine(_fadeFrame);
                StartCoroutine(routine);
            }
        }

        // Update is called once per frame
        void Update()
        {
            //  クリア処理
            if (treasureCount == clearNum)
            {
                _state = State.CLEAR;
                _clearImage.SetActive(true);
                this.DelayMethod(() => { _isInput = true; }, 10);
            }

            //  ゲームオーバー処理
            else if (_player.HP <= 0)
            {
                _state = State.GAME_OVER;
                _gameoverImage.SetActive(true);
                this.DelayMethod(() => { _isInput = true; }, 10);
            }
            text.text = "☆  " + treasureCount + " / " + clearNum;

            //  ゲームオーバー & ゲームクリア処理
            if (_isInput)
            {
                //  アクティブ切替
                _canvas.gameObject.SetActive(true);

                //  A:リトライ
                if(MyInput.MyInputManager.AllController.A)
                {
                    //  シーンの再読み込み
                    SceneManager.LoadScene(0);
                }

                //  B:タイトル遷移
            }

        }


        public void GetTreasure()
        {
            treasureCount++;
        }

        
    }
}