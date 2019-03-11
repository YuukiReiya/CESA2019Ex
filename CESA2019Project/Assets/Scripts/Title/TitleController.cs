//  番場 宥輝
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MethodExpansion;
using UnityEngine.SceneManagement;
using Framework.Fade;
using Framework.Sound;

namespace Title.Scene
{
    public class TitleController : MonoBehaviour
    {
        [System.Serializable]
        struct Menucursor
        {
            public Image gameStart;
            public Image tutorial;
            public Image gameEnd;
        }
        
        [SerializeField] float _waitFrame = 120;
        [SerializeField] float _fadeFrame = 45;
        [SerializeField] Menucursor _cursor;

        enum Menu
        {
            GANE_START,
            TUTORIAL,
            GAME_END
        }
        Menu _menu;
        bool _isInput;

        private void Awake()
        {
            Application.targetFrameRate = 60;
        }

        // Start is called before the first frame update
        void Start()
        {
            _menu = Menu.GANE_START;
            _isInput = false;
            ChangeCursor(_menu);
            if (FadeManager.Instance)
            {
                var routine = FadeManager.Instance.FadeOutCoroutine(_fadeFrame);
                StartCoroutine(routine);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (FadeManager.Instance.IsFade) { return; }

            ChangeMenu();

            if (MyInput.MyInputManager.AllController.A || Input.GetKeyDown(KeyCode.Space))
            {
                Transition();
            }
        }

        /// <summary>
        /// メニュー選択
        /// </summary>
        void ChangeMenu()
        {
            var input = MyInput.MyInputManager.AllController;

            //  スティック入力が立っていれば処理しない
            if (_isInput) { return; }

            //  現在メニュー
            int iMenu = (int)_menu;

            //  上
            if (input.LStick.y > 0)
            {
                //  スティック入力フラグの更新
                --iMenu;
                iMenu = iMenu < (int)Menu.GANE_START ? (int)Menu.GAME_END : iMenu;
                _isInput = true;

                //  指定フレーム待機後、フラグを戻す
                this.DelayMethod(
                    () =>
                    {
                        _isInput = false;
                    },
                    _waitFrame
                    );

                //  効果音
                SoundManager.Instance.PlayOnSE("Menu");
            }

            //  下
            if (input.LStick.y < 0)
            {
                //  スティック入力フラグの更新
                ++iMenu;
                iMenu = iMenu > (int)Menu.GAME_END ? (int)Menu.GANE_START : iMenu;
                _isInput = true;

                //  指定フレーム待機後、フラグを戻す
                this.DelayMethod(
                    () =>
                    {
                        _isInput = false;
                    },
                    _waitFrame
                    );

                //  効果音
                SoundManager.Instance.PlayOnSE("Menu");
            }

            //  設定メニューの変更
            _menu = (Menu)iMenu;

            //  カーソル位置更新
            ChangeCursor(_menu);

        }

        /// <summary>
        /// シーン遷移
        /// </summary>
        void Transition()
        {
            switch(_menu)
            {
                case Menu.GANE_START:
                    {
                        GamePlay();
                        break;
                    }
                case Menu.TUTORIAL:
                    {
                        break;
                    }
                case Menu.GAME_END:
                    {
                        SoundManager.Instance.PlayOnSE("Decision");
                        Application.Quit();
                        break;
                    }
            }
        }

        /// <summary>
        /// ゲームシーン遷移
        /// </summary>
        void GamePlay()
        {
            SoundManager.Instance.PlayOnSE("Decision");
            var routine = FadeManager.Instance.FadeInCoroutine(
                 _fadeFrame,
                 () =>
                 {
                     SceneManager.LoadScene("Stage00");
                 }
                 );
            StartCoroutine(routine);
        }

        /// <summary>
        /// カーソル変更
        /// </summary>
        void ChangeCursor(Menu menu)
        {
            switch(menu)
            {
                case Menu.GANE_START:
                    _cursor.gameStart.gameObject.SetActive(true);
                    _cursor.tutorial.gameObject.SetActive(false);
                    _cursor.gameEnd.gameObject.SetActive(false);
                    break;
                case Menu.TUTORIAL:
                    _cursor.gameStart.gameObject.SetActive(false);
                    _cursor.tutorial.gameObject.SetActive(true);
                    _cursor.gameEnd.gameObject.SetActive(false);
                    break;
                case Menu.GAME_END:
                    _cursor.gameStart.gameObject.SetActive(false);
                    _cursor.tutorial.gameObject.SetActive(false);
                    _cursor.gameEnd.gameObject.SetActive(true);
                    break;
            }
        }
    }
}
