using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public GameObject[] go_events;

    //void OnTriggerEnter(Collider col)
    //{
    //    //transform.parent.GetComponent<EventHandler>();
    //}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Trigger")
        {
            int i = Random.Range(0, go_events.Length);
            Instantiate(go_events[i]);
        }
    }


}
