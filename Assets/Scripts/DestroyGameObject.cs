using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour {

    // Use this for initialization
    GameObject obj;
    ParticleSystem pr;
	void Start () {
        //obj = GetComponent<GameObject>();
        //Destroy(obj, 2f);
	}

    private void OnEnable()
    {
        pr = GetComponent<ParticleSystem>();
        pr.Play();
    }

}
