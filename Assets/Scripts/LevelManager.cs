using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        // Application.LoadLevel(name);
        SceneManager.LoadScene(name);
        ResetBrickCount();
    }

    public void LoadNextLevel()
    {
        ResetBrickCount();
        //Application.LoadLevel(Application.loadedLevel + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0) //last brick destroyed
        {
            LoadNextLevel();
        }
    }

    public void QuitRequest()
    {
        Application.Quit();
        Debug.Log("I Want to quit!");
    }

    public void ResetBrickCount()
    {
        Brick.breakableCount = 0;
    }

}
