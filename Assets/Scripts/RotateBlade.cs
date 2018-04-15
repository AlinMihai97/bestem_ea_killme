using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class RotateBlade : MonoBehaviour {

    public float rotateSpeed = 360;

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

}
