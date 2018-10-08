using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    public List<GameObject> goL_targets;
    public bool b_targLifeCycle = true;
    public int i_targNum;

    // Use this for initialization
    void Start()
    {
        i_targNum = 0;
        //SetObjectsInactive();
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
        goL_targets[i_targNum].SetActive(true);
        i_targNum++;
        if (i_targNum == 3)
        {
            LoopFinished();
        }
    }

    private void LoopFinished()
    {
        //Add Scorecounter
        //Add wincondition
        //Add Audio
        i_targNum = 0;

    }
}
