using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public GameObject[] go_events;
    public GameObject go_Eagle_Cam;
    public GameObject spawnedBoi;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Trigger")
        {
            int i = Random.Range(0, go_events.Length);
            Instantiate(go_events[i]);
            spawnedBoi = Instantiate(go_Eagle_Cam);
            EagleCam(col.transform.parent.GetChild(0).gameObject);
        }
    }

    //calls te parameter reset function for the eagle cam.
    //Call this function when you want to activate an event camera (with eagle PoV)
    void EagleCam(GameObject go)
    {
        if (spawnedBoi == null)
        {
            Debug.LogError("Eagle Cam has not been assigned.");
        }
        else
        {
            spawnedBoi.GetComponent<EagleCamFollow>().ParamReset(go);
        }
    }
}

