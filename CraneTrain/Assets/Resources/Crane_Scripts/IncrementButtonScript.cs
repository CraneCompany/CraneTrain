using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncrementButtonScript : MonoBehaviour {

    private int b_buttonValue;
    private Text textComp;
    //public int test;

    // Use this for initialization
    void Start () {
        //Debug.Log(gameObject.GetComponent<Text>());
        //Debug.Log(textComp);
        textComp = gameObject.GetComponent<Text>();
        //Debug.Log(textComp);
    }
	
	// Update is called once per frame
	public void Plus1()
    {
        b_buttonValue++;
        UpdateValue();
    }

    public void Minus1()
    {
        b_buttonValue--;
        UpdateValue();
    }

    void UpdateValue()
    {
        if (b_buttonValue < 0)
        {
            b_buttonValue = 0;
        }
        textComp.text = b_buttonValue.ToString();
    }
}
