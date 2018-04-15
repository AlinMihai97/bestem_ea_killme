using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAwayController : MonoBehaviour {

    public List<Transform> goUp;
    public List<Transform> goDown;

    public float lenght;

    public float speed;
	// Use this for initialization
	void Start () {
        StartCoroutine(Move());
	}
	

    IEnumerator Move()
    {
        float first = goUp[0].position.y;
        while(goUp[0].position.y - first < lenght)
        {
            foreach(Transform tr in goUp)
            {
                tr.position += Vector3.up * speed * Time.fixedDeltaTime;
            }
            foreach(Transform tr in goDown)
            {
                tr.position += Vector3.down * speed * Time.fixedDeltaTime;
            }
            yield return null;
        }
    }
	
}
