using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HandleData : MonoBehaviour
{
    private DataExport cs_data;

    public void StoreData()
    {
        cs_data = GameObject.Find("Data").GetComponent<DataExport>();
        if (cs_data != null)
        {
            string scene = SceneManager.GetActiveScene().name;
            cs_data.SaveData(scene);
        }
    }
}
