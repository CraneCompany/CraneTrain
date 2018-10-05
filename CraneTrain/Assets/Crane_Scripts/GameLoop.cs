using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{

    #region Variables GameLoop
    public List<GameObject> goL_targets;
    public bool b_targLifeCycle = true;
    public int i_targNum;
    #endregion

    // Use this for initialization
    void Start()
    {
        i_targNum = 0;
        SetObjectsInactive();
        NextBlock();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SetObjectsInactive()
    {
        foreach (GameObject targ in goL_targets)
        {
            if (targ.activeInHierarchy)
            {
                targ.SetActive(false);
            }
        }
    }

    public void NextBlock()
    {
        if (i_targNum <= 2)
        {
            goL_targets[i_targNum].SetActive(true);
            i_targNum++;
        }
        else
        {
            //Change later!
            i_targNum = 0;
            TrainLoop();
            //SceneManager.LoadScene("Menu");
        }
    }

    void TrainLoop()
    {
        goL_targets[i_targNum].SetActive(true);
    }
}
