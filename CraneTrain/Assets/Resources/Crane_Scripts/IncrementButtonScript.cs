using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncrementButtonScript : MonoBehaviour {

    public int i_buttonValue;
    private Text textComp;
    private ParameterManager cs_parameterManager;

    // Use this for initialization
    void Start () {
        cs_parameterManager = GameObject.Find("ParameterManagerObj").GetComponent<ParameterManager>();
        textComp = gameObject.GetComponent<Text>();
    }
	
	// Update is called once per frame
	public void Plus1()
    {
        i_buttonValue++;
        UpdateValue();
    }

    public void Minus1()
    {
        i_buttonValue--;
        UpdateValue();
    }

    void UpdateValue()
    {
        if (i_buttonValue < 0)
        {
            i_buttonValue = 0;
        }
        textComp.text = i_buttonValue.ToString();
        cs_parameterManager.UpdateParameters();
    }
}
