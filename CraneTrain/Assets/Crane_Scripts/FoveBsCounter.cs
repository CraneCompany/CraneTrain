using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoveBsCounter : MonoBehaviour {
    private int i_timer = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (i_timer == 2)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
            Destroy(gameObject.GetComponent<FoveBsCounter>());
        }
        i_timer++;
	}
}
