using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;


namespace Game.Planet
{
    public class Gravite : MonoBehaviour
    {
       
        [SerializeField]PlayerController player;
        // Start is called before the first frame update
        
        
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