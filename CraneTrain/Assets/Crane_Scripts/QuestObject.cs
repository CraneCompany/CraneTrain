using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour {
    private GazeableObject GazeableObject;

	// Use this for initialization
	void Start () {
        GazeableObject = GetComponent<GazeableObject>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T) && GazeableObject.OnTarget())
        {
            GetComponent<Renderer>().material.color = Color.red;
        } 
	}
}
