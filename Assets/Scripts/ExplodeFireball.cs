using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeFireball : MonoBehaviour {

    Animator anim;
    public float delay = 5;
    float count_seconds = 0;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if(count_seconds < delay)
        {
            count_seconds += Time.deltaTime;
        }
        else
        {
            anim.SetTrigger("explosion");
            count_seconds = 0;
        }
	}
}
