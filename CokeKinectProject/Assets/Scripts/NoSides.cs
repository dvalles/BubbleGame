using UnityEngine;
using System.Collections;

public class NoSides : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > 2.77f)
            transform.position = new Vector3(2.77f, transform.position.y, transform.position.z);
        if (transform.position.x < -2.79f)
            transform.position = new Vector3(-2.79f, transform.position.y, transform.position.z);

    }
}
