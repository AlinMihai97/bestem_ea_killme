using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class MoveCamera : MonoBehaviour {


    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -5);
    bool inAnim = false;
    public float cameraSpeed = 8.0f;
    PlatformerCharacter2D player_to_move;

    private float startTime;
    private float journyLength;

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
            //transform.position = Vector3.Lerp(transform.position, target.position + offset, (Time.time - startTime) * cameraSpeed / journyLength);
            transform.position = Vector3.MoveTowards(transform.position, target.position + offset, cameraSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position, target.position + offset) < 0.01)
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
    public void changeTargetAnim(Transform newTarget, PlatformerCharacter2D move)
    {
        target = newTarget;
        SetPlayerScript(move);
        startTime = Time.deltaTime;
        journyLength = Vector3.Distance(transform.position, target.position);
        inAnim = true;
    }
    public void SetPlayerScript(PlatformerCharacter2D move)
    {
        player_to_move = move;
    }
}
