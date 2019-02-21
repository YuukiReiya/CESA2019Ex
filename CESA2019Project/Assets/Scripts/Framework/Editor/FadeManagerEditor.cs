/// <summary>
/// 番場 宥輝
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

/// <summary>
/// 名前空間
/// </summary>
namespace Framework.Fade
{
    /// <summary>
    /// フェード管理マネージャーのエディタ拡張
    /// </summary>
    [CustomEditor(typeof(FadeManager))]
    public class FadeManagerEditor : Editor
    {
        /// <summary>
        /// インスペクター表示切替
        /// </summary>
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            FadeManager fade = target as FadeManager;

            if (GUILayout.Button("Create Need Components!"))
            {
                if (!fade.gameObject.GetComponent<Canvas>())
                {
                    Debug.Log("Canvasがありません。生成します。");
                    fade.gameObject.AddComponent<Canvas>();
                }

                if (!fade.gameObject.GetComponent<CanvasGroup>())
                {
                    Debug.Log("CanvasGroupがありません。生成します。");
                    fade.gameObject.AddComponent<CanvasGroup>();
                }

                if (!fade.gameObject.GetComponent<CanvasScaler>())
                {
                    Debug.Log("CanvasScalerがありません。生成します。");
                    fade.gameObject.AddComponent<CanvasScaler>();
                }

                if (!fade.gameObject.GetComponent<GraphicRaycaster>())
                {
                    Debug.Log("GraphicRaycasterがありません。生成します。");
                    fade.gameObject.AddComponent<GraphicRaycaster>();
                }

                fade.Initialize();
                Debug.Log("コンポーネントの初期化を行いました。");
            }
        }
    }
}