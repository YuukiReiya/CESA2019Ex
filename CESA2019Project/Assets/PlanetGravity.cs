////
//伊藤陸人//
////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGravity : MonoBehaviour
{
    public GameObject _planet;   // 引力の発生する星
    public float _coefficient;   // 万有引力係数
    Rigidbody2D _rigidbody2D;  
    
    // Start is caed before the first frame update
    void Start()
    {
        _rigidbody2D = _planet.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    void FixedUpdate()
    {
        // 星に向かう向きの取得
        var _direction = _planet.transform.position - transform.position;
        // 星までの距離の２乗を取得
        var _distance = _direction.magnitude;
        _distance *= _distance;
        // 万有引力計算
        var _gravity = _coefficient * _rigidbody2D.mass * GetComponent<Rigidbody>().mass / _distance;

        // 力を与える
        _rigidbody2D.AddForce(_gravity * _direction.normalized);
    }
}
