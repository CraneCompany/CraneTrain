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
        DeleteOnLook();
	}

    void DeleteOnLook()
    {
        if (GazeableObject.OnTarget())
        {
            //GlobalManager.singleton_GlobalManager.DestroyBlock();
        }
    }
}
