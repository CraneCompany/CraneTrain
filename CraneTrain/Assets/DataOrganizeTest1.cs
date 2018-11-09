using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataOrganizeTest1 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            test();
        }
    }

    void test()
    {
        string scene = "trainingmap";
        if (Directory.Exists(@Directory.GetCurrentDirectory() + "\\CSV\\" + scene))
        {
            Debug.Log("scene exists");
        }
        else
        {
            Debug.Log("scene doesnt exists");
            Directory.CreateDirectory(@Directory.GetCurrentDirectory() + "\\CSV\\" + scene);
        }
        
    }
}
