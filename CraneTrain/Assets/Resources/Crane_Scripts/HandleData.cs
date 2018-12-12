using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HandleData : MonoBehaviour
{
    GameObject Data;
    private DataExport cs_data;

    public void StoreData()
    {
        Data = GameObject.Find("Data");
        if (Data != null)
        {
            cs_data = Data.GetComponent<DataExport>();
            string scene = SceneManager.GetActiveScene().name;
            cs_data.SaveData(scene);
        }
        Data = null;
    }
}
