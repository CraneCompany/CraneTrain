using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    private AudioManager cs_audioManager;
    private GlobalParameterScript cs_globalParameters;

    public int i_globalScore;
    public int i_lvlReq = 5;

    private int i_prevScore;
    private bool b_lvlUpPlayed;
    private int i_currentLvl;

    // Use this for initialization
    void Start () {
        GameObject go_globalGameobject = GameObject.Find("_GlobalGameObject");
        cs_audioManager = go_globalGameobject.GetComponent<AudioManager>();
        cs_globalParameters = go_globalGameobject.GetComponent<GlobalParameterScript>();
        i_lvlReq = cs_globalParameters.i_lvlReq;

        if (i_lvlReq<=0)
        {
            i_lvlReq = 1;
        }
        
        i_globalScore = 0;
        i_prevScore = 0;
        i_currentLvl = 0;
    }

    // Update is called once per frame
    void Update () {
        LvlUp();

	}

    public void ScoreInscreased()
    {
        i_globalScore++;
        if (i_globalScore != i_prevScore)
        {
            b_lvlUpPlayed = !b_lvlUpPlayed;
        }
        i_prevScore = i_globalScore;
    }

    void LevelFinished()
    {
        if (cs_globalParameters.i_amountToFinish == i_globalScore)
        {
            //klaaaar, geef door aan cranescenechanger
        }
    }

    public void LvlUp()
    {
        if (i_globalScore%i_lvlReq == 0 && !b_lvlUpPlayed)
        {
            i_currentLvl++;
            cs_audioManager.LvlUpSound();
            b_lvlUpPlayed = true;
        }
    }
}
