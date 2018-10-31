using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    private AudioManager am_Audio;
    private GlobalParameterScript cs_globalParameters;

    public int i_globalScore;
    public int i_lvlReq = 5;

    private int i_prevScore;
    private bool b_lvlUpPlayed;
    private int i_currentLvl;

    // Use this for initialization
    void Start () {
        cs_globalParameters = GameObject.Find("_GlobalGameObject").GetComponent<GlobalParameterScript>();
        i_lvlReq = cs_globalParameters.i_lvlReq;

        am_Audio = GameObject.Find("_ScriptManagerObj").GetComponent<AudioManager>();
        i_globalScore = 0;
        i_prevScore = 0;
        i_currentLvl = 0;
    }

    // Update is called once per frame
    void Update () {
        LvlUp();
        ScoreInscreased();
	}

    void ScoreInscreased()
    {
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
            am_Audio.LvlUpSound();
            b_lvlUpPlayed = true;
        }
    }
}
