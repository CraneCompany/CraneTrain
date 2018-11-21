using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActiveRigManager : MonoBehaviour {

    public GameObject go_foveRig;
    private DataExport cs_data;

	// Use this for initialization
	public void rigActive () {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            go_foveRig.SetActive(true);
    }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            go_foveRig.SetActive(false);
        }
    }
}
