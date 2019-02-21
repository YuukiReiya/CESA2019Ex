/// <summary>
///　番場 宥輝
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 名前空間
/// </summary>
namespace Utility
{
    /// <summary>
    /// 空のオブジェクトを生成するだけのコンテキストメニュー
    /// </summary>
    public class GameObjectFactor : MonoBehaviour
    {

        [ContextMenu("CreateEmptyGameObject")]
        public void CreateEmpty()
        {
            GameObject Empty = new GameObject("Empty");
        }
    }
}
