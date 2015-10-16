using UnityEngine;
using System.Collections;

public class BubbleGrow : MonoBehaviour {

	public float maxScale;
	public float minScale;
	public float growSpeed;
	public float shrinkSpeed;
	private bool shrinking;

	// Use this for initialization
	void Start () {
		shrinking = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localScale.x <= maxScale && !shrinking)
		{
			transform.localScale += new Vector3(growSpeed, growSpeed, 0);
		}
		else if (shrinking && transform.localScale.x >= minScale)
		{
			transform.localScale -= new Vector3(shrinkSpeed, shrinkSpeed, 0);
		}
		else
		{}
	}

	public void setShrinking(bool shrink)
	{
		shrinking = shrink;
	}

}
