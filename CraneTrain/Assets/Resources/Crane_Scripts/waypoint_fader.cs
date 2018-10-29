using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint_fader : MonoBehaviour
{

    public Material mat_waypoint;
    private Color col_mat;
    private Color col_newCol;
    private float f_counter = 0;

    void Start()
    {
        col_mat = mat_waypoint.color;
    }

	// Update is called once per frame
	void Update ()
	{
	    f_counter += 0.05f;
	    col_newCol = col_mat;
	    col_newCol.a = Mathf.Sin(f_counter) + 1;

	    mat_waypoint.color = col_newCol;
	}
}
