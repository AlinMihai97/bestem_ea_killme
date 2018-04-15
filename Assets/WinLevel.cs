using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLevel : MonoBehaviour {

    public float dimScreenTime = 2f;
    public string nextLevelName;
    public Image dimImg;

    public string currentScene;

    public bool win;
    private bool firstPress;

    public static WinLevel instance;

    private void Awake()
    {
        instance = this;
        win = false;
        firstPress = true;
    }

    private void Update()
    {
        if(win && firstPress)
        {
            LoadNextLevel();
            firstPress = false;
            win = false;
        }
    }

    public void StartFromMenu()
    {
        SceneManager.LoadScene("World");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void LoadNextLevel()
    {
        StartCoroutine(ChangeLevel());
    }

    IEnumerator DimScreen()
    {
        Color begin = dimImg.color;
        Color finish = dimImg.color;
        finish.a = 1;
        float startTime = Time.time;
        float diff = Time.time - startTime;
        while(diff < dimScreenTime)
        {
            diff = Time.time - startTime;
            dimImg.color = Color.Lerp(begin, finish, diff / dimScreenTime);
            yield return null;
        }
    }

    IEnumerator BrightScreen(AsyncOperation load)
    {
        Color begin = dimImg.color;
        Color finish = dimImg.color;
        finish.a = 0;
        
        //while(!load.isDone)
        //{
        //    yield return null;
        //}
        float startTime = Time.time;
        float diff = Time.time - startTime;
        while (diff < dimScreenTime)
        {
            diff = Time.time - startTime;
            dimImg.color = Color.Lerp(begin, finish, diff / dimScreenTime);
            yield return null;
        }
    }

    IEnumerator ChangeLevel()
    {
        yield return DimScreen();
        AsyncOperation load = SceneManager.LoadSceneAsync(nextLevelName);
        load.allowSceneActivation = true;
        yield return BrightScreen(load);
        //load.allowSceneActivation = true;
    }

}
