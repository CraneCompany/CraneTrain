using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveEventSpawn : MonoBehaviour {

    public GameObject EventObject;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Trigger")
        {
            Instantiate(EventObject);
        }
    }
}
