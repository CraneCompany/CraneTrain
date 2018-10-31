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
            Debug.Log("SET ACTIVE");

            go_foveRig.SetActive(true);
    }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            go_foveRig.SetActive(false);
        }
    }

    public void TutorialSwitch()
    {

    }

    public void AdamTestSwitch()
    {
        HandleData();
        SceneManager.LoadScene("Testing1");
    }

    public void GroceryTestSwitch()
    {

    }

    public void ParkTestSwitch()
    {

    }

    private void HandleData()
    {
        cs_data = GameObject.Find("Data").GetComponent<DataExport>();
        if (cs_data != null)
        {
            string scene = SceneManager.GetActiveScene().name;
            cs_data.SaveData(scene);
        }
    }
}
