using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GazeableObject gazeableObject;
    private GameLoop gameLoop;
    private bool b_timer;
    private float f_lifeTime = 10, f_timer = 0;
    // Use this for initialization
    void Start()
    {
        gameLoop = GameObject.Find("GameLoop").GetComponent<GameLoop>();
        gazeableObject = GetComponent<GazeableObject>();
        b_timer = gameLoop.b_targLifeCycle;
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
            gameLoop.NextBlock();
            DestroyMe();
            //GlobalManager.singleton_GlobalManager.DestroyBlock();
        }
    }

    void LifeCycle()
    {
        if (b_timer)
        {
            if (f_timer >= f_lifeTime)
            {
                gameLoop.NextBlock();
                DestroyMe();
            }
            f_timer += 1 * Time.deltaTime;
        }
    }

    private void DestroyMe()
    {
        this.gameObject.SetActive(false);
    }
}
