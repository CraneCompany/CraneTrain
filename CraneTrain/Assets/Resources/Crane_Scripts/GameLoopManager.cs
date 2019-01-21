using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameLoopManager : MonoBehaviour
{
    public List<GameObject> goL_targets;
    public GlobalParameterScript cs_globalParameterScript;
    public ScoreManager cs_scoreManager;
    public SceneChanger cs_sceneChanger;
    private AddBoardToCamera cs_addBoardToCam;

    private int i_targNum;
    private bool b_blockDestroyed = false;
    private float f_blockTime = 0.0f;
    private bool b_onTarget = false;
    private SEEN targSeen = SEEN.NONE;

    // Use this for initialization
    void Start()
    {
        cs_globalParameterScript = GameObject.Find("_GlobalGameObject").GetComponent<GlobalParameterScript>();
        cs_scoreManager = GetComponent<ScoreManager>();
        cs_sceneChanger = GameObject.Find("_GlobalGameObject").GetComponent<SceneChanger>();
        cs_addBoardToCam = GetComponent<AddBoardToCamera>();

        i_targNum = 0;

        AddTargetsToList();
        NextBlock();
    }

    void AddTargetsToList()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Target"))
        {
            goL_targets.Add(go);
            go.SetActive(false);

        }
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
        //tbo
        if (cs_globalParameterScript.i_amountToFinish == cs_scoreManager.i_globalScore)
        {
            cs_addBoardToCam.RemoveBoardFromCam();
            cs_sceneChanger.AmsterdamScene();
        }
    }

    /// <summary>
    /// Sets the data values to given params
    /// </summary>
    /// <param name="status">Parameter value to for block destroyed (true is destroyed, false is alive).</param>
    /// <param name="time">Parameter value for the reaction time, if not destroyed keep 0.0f</param>
    /// <returns></returns>
    public void PrepareDataVars(SEEN _seen, float time)
    {
        targSeen = _seen;
        f_blockTime = time;
    }
    public void PrepareDataVars(SEEN _seen)
    {
        targSeen = _seen;
    }

    public SEEN GetTargData()
    {
        return targSeen;
    }
    public float GetTargTime()
    {
        return f_blockTime;
    }

    public void OnOffTarget(bool status)
    {
        b_onTarget = status;
    }

    public bool GetOnOffTarget()
    {
        return b_onTarget;
    }

    public void ResetParams()
    {
        f_blockTime = 0;
        targSeen = SEEN.NONE;
    }

    private void LoopFinished()
    {
        i_targNum = 0;
    }
}
