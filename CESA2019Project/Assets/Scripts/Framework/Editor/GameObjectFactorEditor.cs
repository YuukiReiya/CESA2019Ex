/// <summary>
/// 番場 宥輝
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Utility;

/// <summary>
/// 名前空間
/// </summary>
namespace Utility
{
    /// <summary>
    /// 空のゲームオブジェクトをボタン生成するためのエディタ拡張
    /// </summary>
    [CustomEditor(typeof(GameObjectFactor))]
    public class GameObjectFactorEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GameObjectFactor gameObjectFactor = target as GameObjectFactor;

            if (GUILayout.Button("CreateEmpty"))
            {
                Debug.Log("生成");
                gameObjectFactor.CreateEmpty();
            }
        }

    }
}