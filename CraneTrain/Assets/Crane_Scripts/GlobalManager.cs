using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalManager : MonoBehaviour {
    public FoveInterfaceBase f_foveInterface;
    public static GlobalManager singleton_GlobalManager;

    #region GameLoop
    public GameObject[] goA_targets;
    public float timer = 3;
    private bool b_activeTarg = false;
    private bool b_isTiming = false;
    private GameObject go_activeTarg;
    #endregion

    void Awake()
    {
        if (singleton_GlobalManager == null)
        {
            singleton_GlobalManager = this;
        }
        else if (singleton_GlobalManager != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(singleton_GlobalManager);
    }

	// Use this for initialization
	void Start ()
	{
        foreach (GameObject targ in goA_targets)
        {
            if (targ.activeInHierarchy)
            {
                targ.SetActive(false);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        Controls();
        GameLoop();
    }

    void Controls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
        //start callibration
        if (Input.GetKeyDown(KeyCode.C))
        {
            f_foveInterface.EnsureEyeTrackingCalibration();
        }
        //quit application
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        //reload scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }

    void GameLoop()
    {
        if (!b_activeTarg)
        {
            foreach (GameObject targ in goA_targets)
            {
                //
                if (targ.activeInHierarchy)
                {
                    b_activeTarg = true;
                    return;
                }
            }
            SpawnNewBlock();
        }
        else
        {
            b_isTiming = true;
        }

        #region Timing
        if (b_isTiming)
        {
            timer -= 1 * Time.deltaTime;
        }

        if (timer <= 0.0)
        {
            if (go_activeTarg != null)
                DestroyBlock();
        }
        #endregion


    }

    void SpawnNewBlock()
    {
        Random r_rand = new Random();
        int i_targ = Random.Range(0, goA_targets.Length - 1);
        b_activeTarg = true;
        goA_targets[i_targ].SetActive(true);
        go_activeTarg = goA_targets[i_targ];
    }

    public void DestroyBlock()
    {
        Destroy(go_activeTarg);
        timer = 3;
        b_activeTarg = false;
    }
}
