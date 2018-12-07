using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBackRing : MonoBehaviour
{

    private Target cs_targetScript;
    private Transform t_childTrans;
    private Vector3 v3_myScales, v3_buScales;
    public float f_shrinkTime; //in seconds
    private float f_x, f_y, f_z;
    public bool b_lookedAt;

    void Start()
    {
        f_shrinkTime = GameObject.Find("_GlobalGameObject").GetComponent<GlobalParameterScript>().f_stareTime;
        cs_targetScript = gameObject.GetComponent<Target>();
        t_childTrans = transform.GetChild(0);
        v3_myScales = transform.localScale;
        b_lookedAt = false;

        v3_buScales = t_childTrans.localScale;
        ResetScales();
    }

    public void ExpandOut()
    {
        if (t_childTrans.localScale.x < v3_buScales.x)
        {
            f_x += ((t_childTrans.localScale.x * v3_myScales.x) / f_shrinkTime) * Time.deltaTime;
            f_y += ((t_childTrans.localScale.y * v3_myScales.y) / f_shrinkTime) * Time.deltaTime;

            t_childTrans.localScale = new Vector3(f_x, f_y, f_z);
            if (t_childTrans.localScale.x >= v3_buScales.x)
            {
                ResetScales();
            }
        }
    }

    public void ShrinkDown()
    {
        f_x -= ((t_childTrans.localScale.x * v3_myScales.x) / f_shrinkTime) * Time.deltaTime;
        f_y -= ((t_childTrans.localScale.y * v3_myScales.y) / f_shrinkTime) * Time.deltaTime;

        //Debug.Log(f_x);
        t_childTrans.localScale = new Vector3(f_x, f_y, f_z);
        if ((t_childTrans.localScale.x*v3_myScales.x) <= v3_myScales.x)
        {
            ResetScales();
            cs_targetScript.PlayerDestroyed();
        }
    }

    void ResetScales()
    {
        t_childTrans.localScale = v3_buScales;
        f_x = v3_buScales.x;
        f_y = v3_buScales.y;
        f_z = v3_buScales.z;
    }
}
