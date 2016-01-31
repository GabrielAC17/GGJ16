using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseBehaviour : MonoBehaviour
{

    private bool isPaused = false;

    // Update is called once per frame
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!isPaused)
            {
                Cursor.visible = true;
                for (int i = 0; i < transform.childCount; ++i)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                    Time.timeScale = 0f;
                }
                isPaused = true;
            }
            else if (isPaused)
            {
                Cursor.visible = false;
                for (int i = 0; i < transform.childCount; ++i)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                    Time.timeScale = 1f;
                }
                isPaused = false;
            }
        }
    }

    public void continuegame()
    {
        if (!isPaused)
        {
            for (int i = 0; i < transform.childCount; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
            isPaused = true;
        }
        else if (isPaused)
        {
            for (int i = 0; i < transform.childCount; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
            isPaused = false;
        }

    }

    public void restartlevel()
    {
        //Application.LoadLevel(Application.loadedLevelName);
        SceneManager.LoadScene("Test");
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void exitgame()
    {
        Time.timeScale = 1f;
        //Application.LoadLevel(0);
        SceneManager.LoadScene(0);
    }
}
