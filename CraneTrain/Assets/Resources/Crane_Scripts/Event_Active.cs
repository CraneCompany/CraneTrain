using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Active: MonoBehaviour
{

    public GameObject go_car;
    public GameObject[] go_waypoints;
    public float f_driveSpeed;

    private int i_currentWP = 0;
    public float f_waypointRadius;

    // Use this for initialization
    void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Vector3.Distance(go_waypoints[i_currentWP].transform.position, go_car.transform.position) <
	        f_waypointRadius && i_currentWP < go_waypoints.Length - 1)
	    {
	        i_currentWP++;
	    }
	    if (i_currentWP <= go_waypoints.Length - 1)
	    {
	        go_car.transform.position = Vector3.MoveTowards(go_car.transform.position,
	            go_waypoints[i_currentWP].transform.position, Time.deltaTime * f_driveSpeed);
	    }

        go_car.transform.LookAt(go_waypoints[i_currentWP].transform);
    }
}
