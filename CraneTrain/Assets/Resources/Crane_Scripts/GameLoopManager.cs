using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLoopManager : MonoBehaviour
{
    public List<GameObject> goL_targets;
    public GlobalParameterScript cs_globalParameterScript;
    public ScoreManager cs_scoreManager;
    public SceneChanger cs_sceneChanger;


    private int i_targNum;
    private bool b_blockDestroyed = false;
    private float f_blockTime = 0.0f;
    private bool b_onTarget = false;

    // Use this for initialization
    void Start()
    {
        cs_globalParameterScript = GameObject.Find("_GlobalGameObject").GetComponent<GlobalParameterScript>();
        cs_scoreManager = GetComponent<ScoreManager>();
        cs_sceneChanger = GameObject.Find("_GlobalGameObject").GetComponent<SceneChanger>();

        i_targNum = 0;
        NextBlock();
    }

    public void NextBlock()
    {
        goL_targets[i_targNum].SetActive(true);
        i_targNum++;
        if (i_targNum == goL_targets.Count)
        {
            LoopFinished();
        }
        TrainingFinished();
    }

    public void TrainingFinished()
    {
        if (cs_globalParameterScript.i_amountToFinish == cs_scoreManager.i_globalScore)
        {
            cs_sceneChanger.Testmap1();
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
    public void PrepareDataVars(bool looking)
    {
        b_blockDestroyed = looking;
    }

    public void OnOffTarget(bool status)
    {
        b_onTarget = status;
    }
    public bool GetSeen()
    {
        return b_blockDestroyed;
    }

    public float GetReactionTime()
    {
        return f_blockTime;
    }

    public bool GetOnOffTarget()
    {
        return b_onTarget;
    }

    private void LoopFinished()
    {
        i_targNum = 0;
    }
}
