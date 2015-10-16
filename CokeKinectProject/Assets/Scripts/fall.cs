using UnityEngine;
using System.Collections;

public class fall : MonoBehaviour {
	private float speed;
	private Rigidbody2D body;
	// Use this for initialization
	void Start () {
        float scaler = 1 + Time.time / 90;
		speed = Random.Range (.5f, 1f);
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		body.velocity = new Vector3(0f, -speed, 0f);
	}
}
