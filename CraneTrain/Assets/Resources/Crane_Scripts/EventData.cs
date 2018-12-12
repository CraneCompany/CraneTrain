using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventData : MonoBehaviour
{
    private float f_lifeTime = 0.0f;
    private bool b_checkGaze = true;
    private FoveInterface cs_foveInterface;
    private Collider col_Event;
    private DataExport cs_dataExport;
    private Event_Active cs_active_event;
    public float recognitionTime = 0.5f;

    public float f_detectRange = 30f;

    // Use this for initialization
    void Start()
    {
        cs_foveInterface = GameObject.Find("Fove Interface").GetComponent<FoveInterface>();
        cs_dataExport = GameObject.Find("Data").GetComponent<DataExport>();
        col_Event = transform.parent.gameObject.GetComponentInChildren<Collider>();
        cs_active_event = GetComponentInParent<Event_Active>();
    }

    // Update is called once per frame
    void Update()
    {
        if (b_checkGaze)
        {
            if (Vector3.Distance(cs_foveInterface.transform.parent.transform.position, col_Event.transform.position) < f_detectRange)
            {
                recognitionTime -= 1 * Time.deltaTime;
                if(recognitionTime <= 0f)
                {
                    f_lifeTime += 1 * Time.deltaTime;
                    if (cs_foveInterface.Gazecast(col_Event))
                    {
                        cs_dataExport.f_reaction = f_lifeTime;
                        cs_dataExport.objSeen = SEEN.YES;
                        cs_active_event.walk = WALKTYPE.stop;
                        b_checkGaze = false;
                    }
                }
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (b_checkGaze)
        {
            if (col.gameObject.name == "Trigger")
            {
                //cs_dataExport.b_newSeen = false;
                cs_dataExport.objSeen = SEEN.NO;
                b_checkGaze = false;
            }
        }
    }
}
