﻿using UnityEngine;
using System.Collections;

public class DeathBubblesManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
