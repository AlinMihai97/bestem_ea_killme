using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeeeeMovement : MonoBehaviour {

    public float speed = 20;
    public Transform parent;
    public Transform endPoint;
	// Update is called once per frame
	void Update ()
    {
        if(parent.position.x > endPoint.position.x)
        {
            parent.position += Vector3.left * Time.deltaTime * speed;
        }
        
            
	}
}
