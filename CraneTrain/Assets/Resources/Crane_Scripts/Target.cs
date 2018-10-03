using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target: MonoBehaviour {
    private GazeableObject GazeableObject;
    private AudioManager am_Audio;
    private bool b_lookedAt;

    // Use this for initialization
    void Start () {
        GazeableObject = GetComponent<GazeableObject>();
        am_Audio = GameObject.Find("_ScriptManagerObj").GetComponent<AudioManager>();   
	}
	
	// Update is called once per frame
	void Update () {
        if  (GazeableObject.OnTarget())
        {
            if (!b_lookedAt)
            {
                GetComponent<Renderer>().material.color = Color.blue;
                am_Audio.PlaySound();

                b_lookedAt = true;
            }
            
        }
        else
        {
            if (b_lookedAt)
            {
                GetComponent<Renderer>().material.color = Color.white;
                b_lookedAt = false;
            }
            
        }
	}
}
