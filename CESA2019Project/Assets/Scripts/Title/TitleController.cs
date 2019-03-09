//  番場 宥輝
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MethodExpansion;
using UnityEngine.SceneManagement;
using Framework.Fade;

namespace Title.Scene
{
    public class TitleController : MonoBehaviour
    {

        const float GAME_START = 0;
        const float TUTORIAL = -60;
        const float GAME_END = -125;
        
        [SerializeField] Image _cursor;
        [SerializeField] float _waitFrame = 120;
        [SerializeField] float _fadeFrame = 45;
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

            if (FadeManager.Instance)
            {
                var routine = FadeManager.Instance.FadeOutCoroutine(_fadeFrame);
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
        /// メニューに合わせてカーソルの表示
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        Vector3 MenuPosition(Menu menu)
        {
            Vector3 pos = _cursor.rectTransform.localPosition;
            switch(_menu)
            {
                case Menu.GANE_START:
                    pos.y = GAME_START;
                    break;
                case Menu.TUTORIAL:
                    pos.y = TUTORIAL;
                    break;
                case Menu.GAME_END:
                    pos.y = GAME_END;
                    break;
            }
            return pos;
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
            }

            //  設定メニューの変更
            _menu = (Menu)iMenu;

            //  カーソル位置更新
            _cursor.rectTransform.localPosition = MenuPosition(_menu);

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
            var routine = FadeManager.Instance.FadeInCoroutine(
                 _fadeFrame,
                 () =>
                 {
                     SceneManager.LoadScene("Stage00");
                 }
                 );
            StartCoroutine(routine);
        }

    }
}
