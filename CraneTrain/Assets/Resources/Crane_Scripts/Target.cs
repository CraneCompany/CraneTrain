using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float f_timer = 0;

    private GazeableObject gazeableObject;
    private GameLoopManager cs_gameLoop;
    private AudioManager cs_Audio;
    private ScoreManager cs_scoreManager;
    private FeedBackRing cs_feedBackRing;
    private GameObject go_scriptManager;
    private bool b_timer;
    private Material m_material;
    private float f_lifeTime, f_t = 0;


    // Use this for initialization
    void Start()
    {
        gazeableObject = GetComponent<GazeableObject>();
        m_material = GetComponent<Renderer>().material;
        cs_feedBackRing = GetComponent<FeedBackRing>();

        go_scriptManager = GameObject.Find("_ScriptManagerObj");
        cs_gameLoop = go_scriptManager.GetComponent<GameLoopManager>();
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
        ColorChange();
    }

    void OnLook()
    {
        if (gazeableObject.OnTarget())
        {
            cs_feedBackRing.ShrinkDown();
            cs_gameLoop.OnOffTarget(true);
        }
        else
        {
            cs_feedBackRing.ExpandOut();
            cs_gameLoop.OnOffTarget(false);
        }
    }

    public void PlayerDestroyed()
    {
        cs_gameLoop.NextBlock();
        cs_Audio.PlayCoinSound();
        cs_scoreManager.i_globalScore++;
        cs_gameLoop.PrepareDataVars(true, (f_timer - (cs_feedBackRing.f_shrinkRate * f_lifeTime)));
        DestroyThis();
    }

    void LifeCycle()
    {
        if (b_timer)
        {
            if (f_timer >= f_lifeTime)
            {
                cs_gameLoop.NextBlock();
                cs_gameLoop.PrepareDataVars(false);
                DestroyThis();
            }
            f_timer += 1 * Time.deltaTime;
        }
    }

    private void DestroyThis()
    {
        //resets reaction time
        f_timer = 0;
        f_t = 0;
        this.gameObject.SetActive(false);
    }

    void ColorChange()
    {
        if (b_timer)
        {
            if (!gazeableObject.OnTarget())
            {
                m_material.color = Color.Lerp(Color.blue, Color.red, f_t);
                if (f_t < 1)
                {
                    f_t += Time.deltaTime / f_lifeTime;
                }
            }
        }
        else
        {
            m_material.color = Color.blue;
        }
    }

}
