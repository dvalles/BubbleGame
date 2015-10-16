using UnityEngine;
using System.Collections;

public class strawReposition : MonoBehaviour {

    Transform child;
    Animator childAnim;
	// Use this for initialization
	void Start () {
        child = transform.GetChild(1);
        childAnim = child.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (childAnim.enabled)
        {
            Debug.Log("This is enabled");
        }
	}
}
