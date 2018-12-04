using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleCamFollow : MonoBehaviour {

    private GameObject go_target;
    private LineRenderer line;

    public int i_timer = 25;
    private float f_time = 0.0f;

    float yRotation;
	// Use this for initialization
	void Start ()
    {
        line = GetComponentInChildren<LineRenderer>();
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
        transform.position = go_target.transform.position;
        yRotation = go_target.transform.eulerAngles.y;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
        CamTimer();
        OrientationLine();
	}

    void CamTimer()
    {
        if(f_time <= 0.0f)
        {
            //this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else
        {
            f_time -= 1 * Time.deltaTime;
        } 
    }

    public void ParamReset(GameObject go)
    {
        f_time = i_timer;
        this.gameObject.SetActive(true);
        go_target = go;
    }

    void OrientationLine()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.forward, out hit, Mathf.Infinity);
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, Vector3.forward * hit.distance);
    }
}
