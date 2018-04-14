using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour {

    static float parallaxFactor = 0.95f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void updateBackgroundPosition(float objectSpeed)
    {
        transform.position += new Vector3(objectSpeed * parallaxFactor, 0, 0);
    }
}
