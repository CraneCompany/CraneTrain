﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParameterManager : MonoBehaviour {
    [HideInInspector]
    public GlobalParameterScript cs_GlobalParameterScript;
    [HideInInspector]
    public IncrementButtonScript[] csA_buttonValues = new IncrementButtonScript[4];

    public Toggle b_lifeCycleToggle;
    public Slider slider_globalVolume;
    public Slider slider_trainingVolume;

    private int i_updateTimer;

    // Use this for initialization
    void Start()
    {
        i_updateTimer = 0;
        cs_GlobalParameterScript = GameObject.Find("_GlobalGameObject").GetComponent<GlobalParameterScript>();

        slider_globalVolume.maxValue = 1;
        slider_globalVolume.minValue = 0;

        slider_trainingVolume.maxValue = 1;
        slider_trainingVolume.minValue = 0;

        GetDefaultValues();
    }

    void GetDefaultValues()
    {
        csA_buttonValues[0].i_buttonValue = cs_GlobalParameterScript.i_targLifeCycle;
        csA_buttonValues[0].GetComponent<Text>().text = cs_GlobalParameterScript.i_targLifeCycle.ToString();

        csA_buttonValues[1].i_buttonValue = (int)cs_GlobalParameterScript.f_stareTime;
        csA_buttonValues[1].GetComponent<Text>().text = cs_GlobalParameterScript.f_stareTime.ToString();

        csA_buttonValues[2].i_buttonValue = cs_GlobalParameterScript.i_lvlReq;
        csA_buttonValues[2].GetComponent<Text>().text = cs_GlobalParameterScript.i_lvlReq.ToString();

        csA_buttonValues[3].i_buttonValue = cs_GlobalParameterScript.i_amountToFinish;
        csA_buttonValues[3].GetComponent<Text>().text = cs_GlobalParameterScript.i_amountToFinish.ToString();

        slider_globalVolume.value = cs_GlobalParameterScript.f_globalVolume;
        slider_trainingVolume.value = cs_GlobalParameterScript.f_trainVolume;

        b_lifeCycleToggle.isOn = cs_GlobalParameterScript.b_targLifeCycle;
    }

    void Update()
    {
        if (i_updateTimer >= 30)
        {
            UpdateParameters();
            i_updateTimer = 0;
        }
        i_updateTimer++;
    }

    public void UpdateParameters () {
        cs_GlobalParameterScript.i_targLifeCycle = csA_buttonValues[0].i_buttonValue;
        cs_GlobalParameterScript.f_stareTime = csA_buttonValues[1].i_buttonValue;
        cs_GlobalParameterScript.i_lvlReq = csA_buttonValues[2].i_buttonValue;
        cs_GlobalParameterScript.i_amountToFinish = csA_buttonValues[3].i_buttonValue;
        cs_GlobalParameterScript.b_targLifeCycle = b_lifeCycleToggle.isOn;
        cs_GlobalParameterScript.f_globalVolume = slider_globalVolume.value;
        cs_GlobalParameterScript.f_trainVolume = slider_trainingVolume.value;

    }
}
