using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour {

    public GameObject timer;

    private void Update()
    {

    }
    public IEnumerator RunTimer(float legth)
    {
        timer.SetActive(true);
        float startTime = Time.time;
        Vector3 endPos = new Vector3(0, 1, 1);
        Vector3 startPos = new Vector3(1, 1, 1);
        while(Time.time - startTime < legth)
        {
            transform.localScale = Vector3.Lerp(startPos, endPos, (Time.time - startTime) / legth);
            yield return null;
        }
        timer.SetActive(false);
    }
}
