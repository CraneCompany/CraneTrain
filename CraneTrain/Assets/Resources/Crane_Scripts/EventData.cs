using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventData : MonoBehaviour
{
    private float f_lifeTime = 0.0f;
    private bool b_seen;
    private FoveInterface cs_foveInterface;
    private Collider col_Event;
    private DataExport cs_dataExport;

    // Use this for initialization
    void Start()
    {
        cs_foveInterface = GameObject.Find("Fove Interface").GetComponent<FoveInterface>();
        cs_dataExport = GameObject.Find("Data").GetComponent<DataExport>();
        col_Event = transform.parent.gameObject.GetComponentInChildren<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        f_lifeTime += 1 * Time.deltaTime;
        if (cs_foveInterface.Gazecast(col_Event))
        {
            cs_dataExport.b_newSeen = true;
            cs_dataExport.f_newReaction = f_lifeTime;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
        if(col.gameObject.name == "Trigger")
        {
            cs_dataExport.b_newSeen = false;
        }
    }
}
