using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class MainScript : MonoBehaviour {

    // Use this for initialization

    public List<GameObject> playerList;
    public GameObject camera;
    int current_player;

	void Start () {
        current_player = 0;
        PlatformerCharacter2D current = playerList[current_player].GetComponent<PlatformerCharacter2D>();
        //current.setAsFocus();

        MoveCamera cameraMovement = camera.GetComponent<MoveCamera>();
        Transform current_transf = playerList[current_player].GetComponent<Transform>();
        cameraMovement.SetPlayerScript(current);
        cameraMovement.changeTarget(current_transf);
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P))
        {
            PlatformerCharacter2D old = playerList[current_player].GetComponent<PlatformerCharacter2D>();
            old.unFocus();
            current_player = (current_player + 1) % playerList.Count;
            PlatformerCharacter2D current = playerList[current_player].GetComponent<PlatformerCharacter2D>();
            MoveCamera cameraMovement = camera.GetComponent<MoveCamera>();
            cameraMovement.changeTargetAnim(playerList[current_player].GetComponent<Transform>(),current);
        }
	}
}
