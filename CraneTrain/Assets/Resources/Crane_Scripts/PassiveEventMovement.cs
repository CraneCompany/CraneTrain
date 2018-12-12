using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveEventMovement : MonoBehaviour {

    public GameObject go_car;
    public GameObject[] go_waypoints;
    public float f_driveSpeed;

    private int i_currentWP = 0;
    public float f_waypointRadius;
	
	// Update is called once per frame
	void Update ()
    {
        StandardMovement();
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
        if(i_currentWP == go_waypoints.Length - 1 && Vector3.Distance(go_waypoints[i_currentWP].transform.position, go_car.transform.position) < f_waypointRadius)
        {
            Destroy(go_car.gameObject);
        }

        go_car.transform.LookAt(go_waypoints[i_currentWP].transform);
    }
}
