using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WALKTYPE
{
    NONE = 0,
    standard = 1,
    stop = 2,
    selfstop = 3
}

public class Event_Active : MonoBehaviour
{
    public WALKTYPE walk = WALKTYPE.standard;
    public GameObject go_car;
    public GameObject[] go_waypoints;
    public float f_driveSpeed;
    public GameObject go_fove;

    private int i_currentWP = 0;
    public float f_waypointRadius;
    private float currentDriveSpeed;
    private float f_timer = 4;

    private bool seen = false;
    public Material eventMat;
    public float r, g, b;

    // Use this for initialization
    void Start()
    {
        go_car.transform.position = go_waypoints[0].transform.position;
        currentDriveSpeed = f_driveSpeed;
        go_fove = GameObject.Find("Fove Rig");
        r = eventMat.color.r;
        g = eventMat.color.g;
        b = eventMat.color.b;
    }

    // Update is called once per frame
    void Update()
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

            case WALKTYPE.selfstop:

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
        if (i_currentWP == go_waypoints.Length - 1 && Vector3.Distance(go_waypoints[i_currentWP].transform.position, go_car.transform.position) < f_waypointRadius)
        {
            eventMat.color = new Color(r, g, b);
            Destroy(go_car.transform.parent.gameObject);
        }

        go_car.transform.LookAt(go_waypoints[i_currentWP].transform);
    }

    void stop()
    {
        if (Vector3.Distance(go_car.transform.position, go_fove.transform.position) < 20 && currentDriveSpeed > 0)
        {
            if (!seen && eventMat != null)
            {
                seen = true;
                eventMat.color = new Color(0, 255, 0);
            }
            currentDriveSpeed -= (4 * Time.deltaTime);
        }
        if (currentDriveSpeed <= 0)
        {
            currentDriveSpeed = 0;
            wait();
        }

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
    }

    void wait()
    {
        f_timer -= 1 * Time.deltaTime;
        if (f_timer <= 0)
        {
            walk = WALKTYPE.standard;
        }
    }


}
