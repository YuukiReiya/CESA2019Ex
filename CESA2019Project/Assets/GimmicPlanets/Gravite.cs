using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;


namespace Game.Plane
{
    public class Gravite : MonoBehaviour
    {
        const int PLAYER_LAYER = 9;
        const int PLANET_LAYER = 10;
        [SerializeField]PlayerController player;
        // Start is called before the first frame update
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {

        }
        
        private void OnTriggerStay2D(Collider2D collision)
        {
            player.SlowSpeed(50f);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            player.SlowSpeed(100f);
        }
    }
}