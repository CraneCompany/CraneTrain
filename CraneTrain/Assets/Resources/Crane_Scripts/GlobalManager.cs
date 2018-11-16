using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalManager : MonoBehaviour
{
    public FoveInterfaceBase f_foveInterface;
    public AddBoardToCamera cs_addboardtocam;
    // Use this for initialization
    void Start()
    {
        cs_addboardtocam = GetComponent<AddBoardToCamera>();
        updateParameters();
    }

    // Update is called once per frame
    void Update()
    {

        Controls();
    }
    void updateParameters()
    {

    }

    void Controls()
    {
        //start callibration
        if (Input.GetKeyDown(KeyCode.C))
        {
            f_foveInterface.EnsureEyeTrackingCalibration();
        }
        //quit application
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        //reload scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            cs_addboardtocam.RemoveBoardFromCam();
            SceneManager.LoadScene(2);
        }
    }
}
