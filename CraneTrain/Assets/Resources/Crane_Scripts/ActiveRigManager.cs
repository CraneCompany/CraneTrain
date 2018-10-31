using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActiveRigManager : MonoBehaviour {

    public GameObject go_foveRig;

	// Use this for initialization
	public void rigActive () {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Debug.Log("SET ACTIVE");
            go_foveRig.SetActive(true);
    }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            go_foveRig.SetActive(false);
        }
    }
}
