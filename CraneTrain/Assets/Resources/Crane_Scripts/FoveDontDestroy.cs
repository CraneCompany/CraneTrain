﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoveDontDestroy : MonoBehaviour {


    void Awake()
    {
        DontDestroyOnLoad(this);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
