using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour {

    // Use this for initialization

    public List<GameObject> playerList;
    public GameObject camera;
    int current_player;

	void Start () {
        current_player = 0;
        PlayerMovement current = playerList[current_player].GetComponent<PlayerMovement>();
        //current.setAsFocus();

        MoveCamera cameraMovement = camera.GetComponent<MoveCamera>();
        Transform current_transf = playerList[current_player].GetComponent<Transform>();
        cameraMovement.SetPlayerScript(current);
        cameraMovement.changeTarget(current_transf);
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.P))
        {
            PlayerMovement old = playerList[current_player].GetComponent<PlayerMovement>();
            old.unFocus();
            current_player = (current_player + 1) % playerList.Count;
            PlayerMovement current = playerList[current_player].GetComponent<PlayerMovement>();
            MoveCamera cameraMovement = camera.GetComponent<MoveCamera>();
            cameraMovement.changeTargetAnim(playerList[current_player].GetComponent<Transform>(),current);
        }
	}
}
