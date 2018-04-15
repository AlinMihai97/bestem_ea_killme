using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class PlayerDieCollision : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Platformer2DUserControl player = collision.gameObject.GetComponent<Platformer2DUserControl>();
            player.Die(false);
        }
    }
}
