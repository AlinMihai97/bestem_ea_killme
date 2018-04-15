using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

    public static EndGame instance;

    public bool isGameOver;

    public float dimScreenTime = 3f;

    public GameObject gameOverGameObject;
    public Text gameOverText;
    public Image gameOverImage;

    private void Awake()
    {
        instance = this;
        isGameOver = false;
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverGameObject.SetActive(true);
        StartCoroutine(ShowGameOverText());
        StartCoroutine(ShowGameOverImage());
        
    }

    IEnumerator WaitForKey()
    {
        while(true)
        {
            if(Input.anyKeyDown)
            {
                WinLevel.instance.RestartLevel();
            }
            yield return null;
        }
    }

    IEnumerator ShowGameOverText()
    {
        float startTime = Time.time;
        float diff = Time.time - startTime;
        while (diff < dimScreenTime)
        {
            diff = Time.time - startTime;
            gameOverText.fontSize = (int)Mathf.Lerp(1, 60, diff / dimScreenTime);
            yield return null;
        }
        StartCoroutine(WaitForKey());
    }

    IEnumerator ShowGameOverImage()
    {
        Color begin = gameOverImage.color;
        Color finish = gameOverImage.color;
        finish.a = 1;
        float startTime = Time.time;
        float diff = Time.time - startTime;
        while (diff < dimScreenTime)
        {
            diff = Time.time - startTime;
            gameOverImage.color = Color.Lerp(begin, finish, diff / dimScreenTime);
            yield return null;
        }
    }
}
