using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour {

    float parallaxFactor = 0.7f;
    float halfSprite;
    public List<Rigidbody2D> rigidbody2DList;
    public List<Transform> transformList;

    SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
        halfSprite = 10.2f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void updateBackgroundPosition(float objectSpeed, Vector3 playerPos)
    {
        for(int i = 0; i < 3; i++)
        {
            rigidbody2DList[i].velocity = Vector2.right * objectSpeed * parallaxFactor;
        }
        //Debug.Log(Vector3.Distance(playerPos, transformList[1].position));
        if (Vector3.Distance(playerPos, transformList[1].position) > halfSprite)
        {
            Vector3 moveBackgrounds = Vector3.right * 2 * halfSprite - new Vector3(0.1f,0,0);
            if(playerPos.x < transformList[1].position.x)
            {
                moveBackgrounds *= -1;
            }

            for (int i = 0; i < 3; i++)
            {
                transformList[i].position += moveBackgrounds;
            }
        }
    }
}
