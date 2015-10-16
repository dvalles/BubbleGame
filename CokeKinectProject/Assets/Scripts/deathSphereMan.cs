using UnityEngine;
using System.Collections;

public class deathSphereMan : MonoBehaviour {

    public float deathTime;
    public float scaleSpeed;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, deathTime);
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale += new Vector3(Time.deltaTime * scaleSpeed,
                                            Time.deltaTime * scaleSpeed,
                                            Time.deltaTime * scaleSpeed);
	}
}
