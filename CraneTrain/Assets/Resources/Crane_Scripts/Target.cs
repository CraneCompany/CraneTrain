using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GazeableObject gazeableObject;
    private GameLoop cs_gameLoop;
    private AudioManager cs_Audio;
    private ScoreManager cs_scoreManager;
    private GameObject go_scriptManager;
    private bool b_timer;
    private float f_lifeTime, f_timer = 0;

    // Use this for initialization
    void Start()
    {
        gazeableObject = GetComponent<GazeableObject>();

        go_scriptManager = GameObject.Find("_ScriptManagerObj");
        cs_gameLoop = go_scriptManager.GetComponent<GameLoop>();
        cs_Audio = go_scriptManager.GetComponent<AudioManager>();
        cs_scoreManager = go_scriptManager.GetComponent<ScoreManager>();

        b_timer = cs_gameLoop.b_targLifeCycle;
        f_lifeTime = cs_gameLoop.f_targLifeCycle;
    }

    // Update is called once per frame
    void Update()
    {
        OnLook();
        LifeCycle();
    }

    void OnLook()
    {
        if (gazeableObject.OnTarget())
        {
            cs_gameLoop.NextBlock();
            cs_Audio.PlayCoinSound();
            cs_scoreManager.i_globalScore++;
            DestroyThis();
            //GlobalManager.singleton_GlobalManager.DestroyBlock();
        }
    }

    void LifeCycle()
    {
        if (b_timer)
        {
            if (f_timer >= f_lifeTime)
            {
                cs_gameLoop.NextBlock();
                DestroyThis();
            }
            f_timer += 1 * Time.deltaTime;
        }
    }

    private void DestroyThis()
    {
        f_timer = 0;
        this.gameObject.SetActive(false);
    }
}
