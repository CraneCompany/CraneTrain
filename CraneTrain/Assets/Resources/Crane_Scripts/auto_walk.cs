﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auto_walk : MonoBehaviour
{

    public GameObject[] go_waypoints;
    public float f_walkSpeed;


    public GameObject go_marker;
    public float f_markerRadius;
    public Material mat_waypoint;

    private int i_currentWP = 0;
    private GameObject go_foveRig;
    private float f_waypointRadius = .5f;

    private float f_markerCounter = 0;

    private Color col_mat;
    private Color col_newCol;

    // Use this for initialization
    void Start ()
	{
		go_foveRig = GameObject.Find("Fove Rig");
	    go_foveRig.transform.position = go_waypoints[0].transform.position;
        go_marker.transform.position = go_waypoints[1].transform.position;
        go_marker.SetActive(true);

	    col_mat = mat_waypoint.color;
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (Vector3.Distance(go_waypoints[i_currentWP].transform.position, go_foveRig.transform.position) <
	        f_waypointRadius && i_currentWP < go_waypoints.Length - 1)
	    {
	        i_currentWP++;
	    }
	    if (i_currentWP <= go_waypoints.Length-1)
	    {
	        go_foveRig.transform.position = Vector3.MoveTowards(go_foveRig.transform.position,
	            go_waypoints[i_currentWP].transform.position, Time.deltaTime * f_walkSpeed);

	        SetMarker();
        }
        
    }

    void PulseFade()
    {
        f_markerCounter += 0.05f;
        col_newCol = col_mat;
        col_newCol.a = Mathf.Sin(f_markerCounter) + 1;
        mat_waypoint.color = col_newCol;
    }

    void Fade()
    {
        col_newCol = col_mat;
        col_newCol.a = 0;
        mat_waypoint.color = col_newCol;
    }

    void SetMarker()
    {
        if (i_currentWP < go_waypoints.Length -1)
        {
            if (Vector3.Distance(go_waypoints[i_currentWP].transform.position, go_foveRig.transform.position) <
                f_markerRadius)
            {
                go_marker.transform.position = go_waypoints[i_currentWP+1].transform.position;
            }
            PulseFade();
        }
        else
        {
            if (Vector3.Distance(go_waypoints[i_currentWP].transform.position, go_foveRig.transform.position) <
                f_markerRadius)
            {
                Fade();
            }
            PulseFade();
        }
    }
}