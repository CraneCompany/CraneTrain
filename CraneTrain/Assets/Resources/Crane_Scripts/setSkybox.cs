using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class setSkybox : MonoBehaviour {

    Camera cam;
    Camera[] cams;

	// Use this for initialization
	void Start ()
    {
        cam = GetComponent<Camera>();
        cams = GetComponentsInChildren<Camera>();
	}

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Scene1")
        {
            cam.clearFlags = CameraClearFlags.SolidColor;
        }
        else if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            cam.clearFlags = CameraClearFlags.SolidColor;
        }
        else
        {
            cam.clearFlags = CameraClearFlags.Skybox;
        }

        foreach (Camera c in cams)
        {
            c.clearFlags = cam.clearFlags;
        }
    }
}
