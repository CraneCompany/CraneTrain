using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    private ActiveRigManager cs_activeRigManager;
    private void Start()
    {
        cs_activeRigManager = GameObject.Find("_GlobalGameObject").GetComponent<ActiveRigManager>();
    }
    // Update is called once per frame
    public void Left () {
        Debug.Log("SWITCH");
        cs_activeRigManager.go_foveRig.SetActive(true);
        SceneManager.LoadScene(1);
    }

    public void Right () {
        Debug.Log("SWITCH");
        cs_activeRigManager.go_foveRig.SetActive(true);
        SceneManager.LoadScene(1);
    }

    public void Testmap1()
    {
        Debug.Log("DebugTest 1");
        cs_activeRigManager.HandleData();
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
