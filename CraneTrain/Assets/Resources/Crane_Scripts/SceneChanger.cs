using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    private ActiveRigManager cs_activeRigManager;
    private GlobalParameterScript cs_globalParameterScript;

    private void Start()
    {
        cs_activeRigManager = GetComponent<ActiveRigManager>();
        cs_globalParameterScript = GetComponent<GlobalParameterScript>();
    }

    public void Left()
    {
        cs_globalParameterScript.b_leftSided = true;
        TrainingScene();
    }

    public void Right()
    {
        cs_globalParameterScript.b_leftSided = false;
        TrainingScene();
    }

    public void TrainingScene()
    {
        cs_activeRigManager.go_foveRig.SetActive(true);
        SceneManager.LoadScene("Training");
    }

    public void MenuScene()
    {
        cs_activeRigManager.go_foveRig.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void TutorialScene()
    {
        cs_activeRigManager.go_foveRig.SetActive(true);
        SceneManager.LoadScene("Tutorial");
    }

    public void AmsterdamScene()
    {
        //gameObject.GetComponent<HandleData>().StoreData();
        cs_activeRigManager.go_foveRig.SetActive(true);
        SceneManager.LoadScene("Amsterdam");
    }

    public void SupermarktScene()
    {
        cs_activeRigManager.go_foveRig.SetActive(true);
        SceneManager.LoadScene("Supermarkt");
    }

    public void Quit()
    {
        gameObject.GetComponent<HandleData>().StoreData();
        Application.Quit();
    }
}
