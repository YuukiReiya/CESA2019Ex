using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;
 

public class MirrorPlanet : MonoBehaviour
{
    PlayerController player;


    public void OnCollisionStay(Collision collision)
    {
        MirrorMove();
    }

    private void MirrorMove()
    {
        StartCoroutine(Mirror(player));
    }
    private IEnumerator Mirror(PlayerController player)
    {
       // player.
        yield return new WaitForSeconds(10f);
    }
}
   