using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WALKTYPE
{
    NONE = 0,
    standard = 1,
    stop = 2,
    hardstop = 3,
    selfstop = 4
}

public class Event_Active: MonoBehaviour
{
    public WALKTYPE walk = WALKTYPE.standard;
    public GameObject go_car;
    public GameObject[] go_waypoints;
    public float f_driveSpeed;
    public GameObject go_fove;

    private int i_currentWP = 0;
    public float f_waypointRadius;

    // Use this for initialization
    void Start ()
	{
        go_car.transform.position = go_waypoints[0].transform.position;
        go_fove = GameObject.Find("Fove Rig");
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (walk)
        {
            case WALKTYPE.NONE:

                break;

            case WALKTYPE.standard:
                StandardMovement();
                break;

            case WALKTYPE.stop:
                stop();
                break;

            case WALKTYPE.hardstop:

                break;
        }
    }

    void StandardMovement()
    {
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

    void stop()
    {
        float currentDriveSpeed = f_driveSpeed;
        if (Vector3.Distance(go_waypoints[i_currentWP].transform.position, go_car.transform.position) <
        f_waypointRadius && i_currentWP < go_waypoints.Length - 1)
        {
            i_currentWP++;
        }
        if (i_currentWP <= go_waypoints.Length - 1)
        {
            go_car.transform.position = Vector3.MoveTowards(go_car.transform.position,
                go_waypoints[i_currentWP].transform.position, Time.deltaTime * currentDriveSpeed);
        }

        go_car.transform.LookAt(go_waypoints[i_currentWP].transform);

        Debug.Log(Vector3.Distance(go_car.transform.position, go_fove.transform.position));
        if (Vector3.Distance(go_car.transform.position, go_fove.transform.position) < 8 && Vector3.Distance(go_car.transform.position, go_fove.transform.position) > 3)
        {
            if(currentDriveSpeed > 0)
            {
                currentDriveSpeed -= 4f * Time.deltaTime;
            } 
            else if ( currentDriveSpeed < 0)
            {
                currentDriveSpeed = 0;
            }
        } 
    }
}
