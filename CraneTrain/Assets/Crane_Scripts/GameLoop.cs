using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour {

    #region GameLoop
    public List<GameObject> goL_targets;
    private bool b_activeTarg = false;
    private bool b_isTiming = false;
    private GameObject go_activeTarg;

    public float f_totalTime = 3;
    private float f_timer;
    public float f_goodTime = 0.5f, f_mediumTime = 1.5f, f_badTime = 3f;
    private int i_goodCount = 0, i_mediumCount = 0, i_badCount = 0;
    public Text txt_good, txt_medium, txt_bad;
    public GameObject go_canvas;
    private float f_endTime = 10f;

    private bool b_scorePrinted = false;
    #endregion

    // Use this for initialization
    void Start ()
	{
	    SetObjectsInactive();
    }
	
	// Update is called once per frame
	void Update ()
	{
		Loop();
	}

    private void Loop()
    {
        if (goL_targets.Count > 0)
        {
            if (!b_activeTarg)
            {
                SpawnNewBlock();
            }
            else
            {
                b_isTiming = true;
            }

            #region Timing

            if (b_isTiming)
            {
                f_timer -= 1 * Time.deltaTime;
            }

            if (f_timer <= 0.0)
            {
                if (go_activeTarg != null)
                {
                    DestroyBlock();
                }
            }
            #endregion
        }
        else
        {
            if (!b_scorePrinted)
            {
                PrintScore();
                b_scorePrinted = true;
            }
            DisplayScore();
        }
    }

    private void SetObjectsInactive()
    {
        foreach (GameObject targ in goL_targets)
        {
            if (targ.activeInHierarchy)
            {
                targ.SetActive(false);
            }
        }
    }

    private void SpawnNewBlock()
    {
        Random r_rand = new Random();
        int i_targ = Random.Range(0, goL_targets.Count - 1);
        b_activeTarg = true;
        goL_targets[i_targ].SetActive(true);
        go_activeTarg = goL_targets[i_targ];
    }

    public void DestroyBlock()
    {
        CalculateScore();
        goL_targets.Remove(go_activeTarg);
        Destroy(go_activeTarg);
        f_timer = f_totalTime;
        b_isTiming = false;
        b_activeTarg = false;
    }

    private void CalculateScore()
    {
        if ((f_totalTime - f_timer) <= f_goodTime)
        {
            i_goodCount += 1;
        }
        else if ((f_totalTime - f_timer) <= f_mediumTime)
        {
            i_mediumCount += 1;
        }
        else
        {
            i_badCount += 1;
        }
    }

    private void PrintScore()
    {
        txt_good.text += i_goodCount.ToString();
        txt_medium.text += i_mediumCount.ToString();
        txt_bad.text += i_badCount.ToString();
    }

    private void DisplayScore()
    {
        go_canvas.SetActive(true);

        f_endTime -= 1 * Time.deltaTime;
        if (f_endTime <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
