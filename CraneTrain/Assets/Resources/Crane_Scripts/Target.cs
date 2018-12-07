using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GazeableObject gazeableObject;
    private GameLoopManager cs_gameLoop;
    private GlobalParameterScript cs_globalParameters;
    private AudioManager cs_Audio;
    private ScoreManager cs_scoreManager;
    private FeedBackRing cs_feedBackRing;
    private GameObject go_scriptManager;
    private bool b_timer;
    private Material m_material;
    private float f_lifeTime, f_timer = 0, f_t = 0;


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

        GameObject go_globalGameobject = GameObject.Find("_GlobalGameObject");
        cs_globalParameters = go_globalGameobject.GetComponent<GlobalParameterScript>();
        cs_Audio = go_scriptManager.GetComponent<AudioManager>();

        b_timer = cs_globalParameters.b_targLifeCycle;
        f_lifeTime = cs_globalParameters.i_targLifeCycle;
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
        cs_scoreManager.ScoreInscreased();
        cs_gameLoop.NextBlock();
        cs_gameLoop.PrepareDataVars(SEEN.YES, f_timer);
        Debug.Log(f_timer);
        cs_Audio.PlayCoinSound();
        DestroyThis();
    }

    void LifeCycle()
    {
        if (b_timer)
        {
            if (f_timer >= f_lifeTime)
            {
                cs_gameLoop.NextBlock();
                cs_gameLoop.PrepareDataVars(SEEN.NO);
                DestroyThis();
            }
            f_timer += 1 * Time.deltaTime;
        }
    }

    private void DestroyThis()
    {
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
