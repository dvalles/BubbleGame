using UnityEngine;
using System.Collections;

public class strawMove : MonoBehaviour {

    Animator anim;
    public float minStrawWait;
    public float maxStrawWait;
    public GameObject parent;

	// Use this for initialization
	void Start () {
        //transform.position = new Vector3(Random.Range(-2.2f, 2.2f), 8.61f, -10.92f);
        minStrawWait += 3;
        maxStrawWait += 3;
        anim = GetComponent<Animator>();
        anim.enabled = false;
        StartCoroutine("sendDown");
        //parent = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    IEnumerator sendDown()
    {
        while (true)
        {
            parent.transform.position = new Vector3(Random.Range(-2.2f, 2.2f), 8.61f, -10.92f);
            anim.enabled = true;
            yield return new WaitForSeconds(3f);
           // Debug.Log(transform.position.x);
            anim.enabled = false;
            yield return new WaitForSeconds(Random.Range(minStrawWait, maxStrawWait));
        }
    }
}
