using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target: MonoBehaviour {
    private GazeableObject GazeableObject;

	// Use this for initialization
	void Start () {
        GazeableObject = GetComponent<GazeableObject>();
	}
	
	// Update is called once per frame
	void Update () {
        if  (GazeableObject.OnTarget())//&& (Input.GetKeyDown(KeyCode.T)))
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
	}
}
