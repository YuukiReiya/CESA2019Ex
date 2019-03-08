using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Game.Enemy
{
    public class EnemyController : Framework.SingletonMonoBehaviour<EnemyController>
    {
        [SerializeField] Enemy[] enemys;
        public int AllEnemyNum { get { return enemys.Length; } }
        public int ActiveEnemyNum { get { return enemys.Where(i => i != null).Count(); } }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Stun()
        {
            foreach (var it in enemys)
            {
                if (it == null) { continue; }
                it.Stun();
            }
        }
    }
}
