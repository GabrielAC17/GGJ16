using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public string sceneToLoad = "test";

	// Use this for initialization
	public void GStart()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
