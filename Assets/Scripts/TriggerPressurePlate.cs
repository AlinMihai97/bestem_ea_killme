using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPressurePlate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public int tip;
    // 0 pentru bolovan
    // 1 pentru usa
    
    // SETEAZA AICI TARGET-UL PENTRU 
    public GameObject target;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            transform.position -= new Vector3(0, 0.15f, 0);
            doAction();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            transform.position += new Vector3(0, 0.15f, 0);
        }
    }

    void doAction()
    {
        switch (tip)
        {
            case 0:
                target.SetActive(true);
                break;
            case 1:
                target.SetActive(false);
                break;
        }
        
    }
}
