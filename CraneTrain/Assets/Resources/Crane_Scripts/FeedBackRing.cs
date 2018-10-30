using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBackRing : MonoBehaviour
{

    private Target cs_targetScript;
    private Transform t_childTrans;
    private Vector3 v3_myScales, v3_buScales;
    public float f_shrinkRate = .02f;
    private float f_x, f_y, f_z;
    public bool b_lookedAt;

    // Use this for initialization
    void Start()
    {
        cs_targetScript = gameObject.GetComponent<Target>();
        t_childTrans = transform.GetChild(0);
        v3_myScales = transform.localScale;
        b_lookedAt = false;

        v3_buScales = t_childTrans.localScale;
        ResetScales();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ExpandOut()
    {
        if (Vector3.Distance(t_childTrans.localScale, v3_buScales) > .3f)
        {
            f_x += f_shrinkRate;
            f_y += f_shrinkRate;

            t_childTrans.localScale = new Vector3(f_x, f_y, f_z);
        }
    }

    public void ShrinkDown()
    {
        f_x -= f_shrinkRate;
        f_y -= f_shrinkRate;

        t_childTrans.localScale = new Vector3(f_x, f_y, f_z);
        if (Vector3.Distance(t_childTrans.localScale, v3_myScales) < .5f)
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
