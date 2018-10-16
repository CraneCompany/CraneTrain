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

    public bool b_blockDestroyed = false;
    public float f_blockTime = 0.0f;

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

    /// <summary>
    /// Sets the data values to given params
    /// </summary>
    /// <param name="status">Parameter value to for block destroyed (true is destroyed, false is alive).</param>
    /// <param name="time">Parameter value for the reaction time, if not destroyed keep 0.0f</param>
    /// <returns></returns>
    public void PrepareDataVars(bool looking, float time)
    {
        b_blockDestroyed = looking;
        f_blockTime = time;
    }
    public void GetBlockData(bool destroyed,  float time)
    {
        destroyed = b_blockDestroyed;
        time = f_blockTime;
    }

    private void LoopFinished()
    {
        i_targNum = 0;
    }
}
