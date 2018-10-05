using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour {

    #region Variables GameLoop
    public List<GameObject> goL_targets;
    private bool b_activeTarg = false;
    private bool b_isTiming = false;
    private GameObject go_activeTarg;

    public float f_totalTime = 3;
    private float f_timer;
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
            //Add timer for switch
            SceneManager.LoadScene("Menu");
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
        goL_targets.Remove(go_activeTarg);
        Destroy(go_activeTarg);
        f_timer = f_totalTime;
        b_isTiming = false;
        b_activeTarg = false;
    } 
}
