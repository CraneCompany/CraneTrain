﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject go_foveRig;
    private GlobalParameterScript cs_globalParameterScript;
    private Animator a_fadePlane;
    private float f_fadeSpeed;

    private void Start()
    {
        f_fadeSpeed = .5f; //1 = 100%
        cs_globalParameterScript = GetComponent<GlobalParameterScript>();

        go_foveRig.SetActive(true);
        a_fadePlane = GameObject.Find("FadePlane").GetComponent<Animator>();
        go_foveRig.SetActive(false);

        a_fadePlane.speed = f_fadeSpeed;
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
        CallEnum("Training", false, true, false);
    }

    public void MenuScene()
    {
        CallEnum("MainMenu", true, false, true);
    }

    public void TutorialScene()
    {
        CallEnum("Tutorial", false, true, false);
    }

    public void AmsterdamScene()
    {
        CallEnum("Amsterdam", false, true, false);
    }

    public void SupermarktScene()
    {
        CallEnum("Supermarkt", false, true, false);
    }

    public void Quit()
    {
        gameObject.GetComponent<HandleData>().StoreData();
        Application.Quit();
    }

    void CallEnum(string sceneName, bool fadeIn, bool fadeOut, bool menu)
    {
        if (!menu)
        {
            go_foveRig.SetActive(true);
        }
        else
        {
            go_foveRig.SetActive(false);
        }
        if (fadeIn)
        {
            a_fadePlane.Play("FadeIn");
        }
        StartCoroutine(ChangeSceneMethod(sceneName, fadeIn, fadeOut));
    }

    IEnumerator ChangeSceneMethod(string sceneName, bool fadeIn, bool fadeOut)
    {
        if (fadeIn)
        {
            yield return new WaitForSeconds(2 / f_fadeSpeed);
        }
        SceneManager.LoadScene(sceneName);
        if (fadeOut)
        {
            a_fadePlane.Play("FadeOut");
        }
        else
        {
            //zet plane op onzichtbaar
            Debug.Log("plane onzichtbaar");
            a_fadePlane.gameObject.GetComponent<MeshRenderer>().material.color = new Color(0,0,0,0);
        }
    }
}
