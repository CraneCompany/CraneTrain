using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    private CraneSceneManager cs_globalParameterScript;
    private void Start()
    {
        cs_globalParameterScript = GameObject.Find("_GlobalParameterScriptObj").GetComponent<CraneSceneManager>();
    }
    // Update is called once per frame
    public void Left () {
        Debug.Log("SWITCH");
        cs_globalParameterScript.go_foveRig.SetActive(true);
        SceneManager.LoadScene(1);
    }

    public void Right () {
        Debug.Log("SWITCH");
        cs_globalParameterScript.go_foveRig.SetActive(true);
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
