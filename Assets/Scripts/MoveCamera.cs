using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {


    public Transform target;
    Vector3 offset = new Vector3(0, 0, -5);
    bool inAnim = false;
    float cameraSpeed = 8.0f;
    PlayerMovement player_to_move;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!inAnim)
        {
            transform.position = target.position + offset;
        }
        else
        {
            Debug.Log("ceva");
            transform.position = Vector3.MoveTowards(transform.position, target.position + offset, cameraSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position, target.position + offset) < 0.1)
            {
                changeTarget(target);
            }
        }
	}

    public void changeTarget(Transform newTarget)
    {
        inAnim = false;
        target = newTarget;
        player_to_move.setAsFocus();
    }
    public void changeTargetAnim(Transform newTarget, PlayerMovement move)
    {
        target = newTarget;
        SetPlayerScript(move);
        inAnim = true;
    }
    public void SetPlayerScript(PlayerMovement move)
    {
        player_to_move = move;
    }
}
