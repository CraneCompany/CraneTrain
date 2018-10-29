using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	// Update is called once per frame
	public void Left () {
        Debug.Log("SWITCH");
        SceneManager.LoadScene(1);
    }

    public void Right () {
        Debug.Log("SWITCH");
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
