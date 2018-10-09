using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLoopManager : MonoBehaviour
{
    public List<GameObject> goL_targets;
    public bool b_targLifeCycle = true;
    public int i_targNum;
    public float f_targLifeCycle = 10;

    // Use this for initialization
    void Start()
    {
        i_targNum = 0;
        NextBlock();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void NextBlock()
    {
        goL_targets[i_targNum].SetActive(true);
        i_targNum++;
        if (i_targNum == goL_targets.Count)
        {
            LoopFinished();
        }
    }

    private void LoopFinished()
    {
        i_targNum = 0;
    }
}
