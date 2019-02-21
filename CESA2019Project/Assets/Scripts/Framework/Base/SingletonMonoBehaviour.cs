/// <summary>
/// 番場 宥輝
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シングルトンの基底クラス
/// テンプレートに近い
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingletonMonoBehaviour<T> : MonoBehaviour where T: MonoBehaviour
{
    //  static instance
    private static T instance = null;

    //  serialize param!
    [Header("Dont Destroy On Load")]
    [SerializeField, Tooltip("ONにするとAwake関数内でDontDestroyOnLoadする")] bool isDefaultDontDestroy = false;

    //  getter
    public static T Instance
    {
        get
        {
            //  null check!
            if (instance == null)
            {
                //  find
                instance = (T)FindObjectOfType(typeof(T));

                //  not found!
                if (instance == null)
                {
                    Debug.LogError("<color=red>" + typeof(T) + "</color>" + " is nothing");
                }
            }
            return instance;
        }
    }

    /// <summary>
    /// Awake
    /// </summary>
    protected virtual void Awake()
    {
        //  static check!
        if (instance != this && instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
    }
}
