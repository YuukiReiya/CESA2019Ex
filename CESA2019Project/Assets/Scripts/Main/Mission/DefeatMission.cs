//  番場 宥輝
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Enemy;

namespace Game.Mission
{
    /// <summary>
    /// 撃破ミッション
    /// </summary>
    public class DefeatMission : MonoBehaviour, IMission
    {
        [SerializeField] int _num;  //  目標撃破数


        //  撃破数の求め方
        //  EnemyControllerのメンバを見て要素数を判定

        /// <summary>
        /// ミッションの達成
        /// </summary>
        bool IMission.Achievement()
        {
            int num = EnemyController.Instance.AllEnemyNum - EnemyController.Instance.AllEnemyNum;

            //  目標数と実際の数を比較
            if (_num <= num)
            {
                return true;
            }

            return false;
        }
        
    }
}