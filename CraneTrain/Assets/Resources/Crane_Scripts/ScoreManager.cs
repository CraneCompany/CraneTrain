using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    private AudioManager am_Audio;
    public int i_globalScore;
    private int i_prevScore;
    public int i_lvlReq = 5;
    private bool b_lvlUpPlayed;
    // Use this for initialization
    void Start () {
        am_Audio = GameObject.Find("_ScriptManagerObj").GetComponent<AudioManager>();
        i_globalScore = 0;
        i_prevScore = 0;
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

    public void LvlUp()
    {
        if (i_globalScore%i_lvlReq == 0 && !b_lvlUpPlayed)
        {
            am_Audio.LvlUpSound();
            b_lvlUpPlayed = true;
        }
    }
}
