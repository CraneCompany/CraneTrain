using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParameterManager : MonoBehaviour {

    private GlobalParameterScript cs_GlobalParameterScript;

    public IncrementButtonScript[] csA_buttonValues = new IncrementButtonScript[4];
    public Toggle b_lifeCycleToggle;

    private int i_updateTimer;

    // Use this for initialization
    void Start()
    {
        i_updateTimer = 0;
        cs_GlobalParameterScript = GameObject.Find("_GlobalParameterScriptObj").GetComponent<GlobalParameterScript>();
    }

    void Update()
    {
        if (i_updateTimer >= 60)
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
    }
}
