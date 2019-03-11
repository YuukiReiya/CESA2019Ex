using System.Collections;
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
        [SerializeField] float _fadeFrame = 45;

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
            _state = State.PLAY;
            if (FadeManager.Instance)
            {
                var routine = FadeManager.Instance.FadeOutCoroutine(_fadeFrame);
                StartCoroutine(routine);
            }
        }

        // Update is called once per frame
        void Update()
        {

            //  1フレーム前のステート
            var prevState = _state;

            //-------------------------------------
            //デバッグ
            if (Input.GetKeyDown(KeyCode.A))
            {
                treasureCount = clearNum;
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                _player.DamageOxygen(999);
            }
            //-------------------------------------

            //  クリア条件の監視
            if (treasureCount == clearNum)
            {
                _state = State.CLEAR;
                //_clearImage.SetActive(true);
                //this.DelayMethod(() => { _isInput = true; }, 10);
            }
            //  ゲームオーバー条件の監視
            else if (_player.HP <= 0)
            {
                _state = State.GAME_OVER;
                //_gameoverImage.SetActive(true);
                //this.DelayMethod(() => { _isInput = true; }, 10);
            }

            //  一度だけ行われるクリア/ゲームオーバー処理
            if (prevState == State.PLAY)
            {
                if (_state == State.CLEAR)
                {
                    SceneManager.LoadScene("GameClear", LoadSceneMode.Additive);
                }
                else if (_state == State.GAME_OVER)
                {
                    SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
                }
            }

            text.text = "☆  " + treasureCount + " / " + clearNum;

            //  ゲームオーバー & ゲームクリア処理
            if (_state != State.PLAY)
            {
                //  A:リトライ
                if (MyInput.MyInputManager.AllController.A)
                {
                    var routine = FadeManager.Instance.FadeInCoroutine(_fadeFrame, () =>
                      {
                      //  シーンの再読み込み
                      SceneManager.LoadScene(1);
                      });
                    StartCoroutine(routine);
                }

                //  B:タイトル遷移
                if (MyInput.MyInputManager.AllController.B)
                {
                    var routine = FadeManager.Instance.FadeInCoroutine(_fadeFrame, () =>
                    {
                    //  シーンの再読み込み
                    SceneManager.LoadScene(0);
                    });
                    StartCoroutine(routine);
                }
            }
        }


        public void GetTreasure()
        {
            treasureCount++;
        }

        /// <summary>
        /// ゲームクリア時の更新処理
        /// </summary>
        void ClearUpdate()
        {
            //  Aでもう一度

            //  Bでタイトル
        }

        /// <summary>
        /// ゲームオーバー時の更新処理
        /// </summary>
        void OverUpdate()
        {

        }
    }
}