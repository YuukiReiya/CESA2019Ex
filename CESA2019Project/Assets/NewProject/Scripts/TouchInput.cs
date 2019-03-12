#if UNITY_EDITOR
#define IS_EDITOR
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タッチインプット
/// </summary>
public class TouchInput : Framework.SingletonMonoBehaviour<TouchInput>
{
#if UNITY_EDITOR

# else


#endif
    //  座標
    public Vector3 position { get; private set; }

    //
}
