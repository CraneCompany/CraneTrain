using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterXSeconds : MonoBehaviour {

    // Use this for initialization
    public float TimeBeforeInactive;
	void Start () {

        Invoke("DestroySelf", TimeBeforeInactive);

	}

    void DestroySelf() { gameObject.SetActive(false); }

}
