using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public GameObject[] go_events;
    public GameObject go_Eagle_Cam;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Trigger")
        {
            int i = Random.Range(0, go_events.Length);
            Instantiate(go_events[i]);
            EagleCam(col.transform.parent.gameObject);
        }
    }

    //calls te parameter reset function for the eagle cam.
    //Call this function when you want to activate an event camera (with eagle PoV)
    void EagleCam(GameObject go)
    {
        if (go_Eagle_Cam == null)
        {
            Debug.LogError("Eagle Cam has not been assigned.");
        }
        else
        {
            go_Eagle_Cam.GetComponent<EagleCamFollow>().ParamReset(go);
        }
    }
}

