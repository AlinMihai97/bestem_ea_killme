using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeObject : MonoBehaviour {

    private Animator anim;
    private PointEffector2D pointEffector;
    private CircleCollider2D explosionArea;

    [Range(0, 1)] public float probabilityOfExplosion; 

    private void Start()
    {
        anim = GetComponent<Animator>();
        pointEffector = GetComponent<PointEffector2D>();
        explosionArea = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if(collision.gameObject.CompareTag("Player"))
        {
            if (Random.value < probabilityOfExplosion)
            {
                Debug.Log("Explode");
                anim.SetTrigger("explode");
                DestroyObject(this);
            }
        }
    }

}
