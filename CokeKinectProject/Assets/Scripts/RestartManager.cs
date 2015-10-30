using UnityEngine;
using System.Collections;

public class RestartManager : MonoBehaviour {

	public BodySourceView bodyView;
	public BubbleManager bubbleMan;
	private int restartCount = 0;
	public int restartWait = 1000;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frames
	void Update () {
		if (bubbleMan.restartCounting && bodyView.bodyOnly == 0)
		{
			restartCount++;
		}
		else
			restartCount = 0;
		Debug.Log("Restart Count: " + restartCount);
		if (restartCount > restartWait) {
			restartCount = 0;
			bubbleMan.restartCounting = false;
			Application.LoadLevel(Application.loadedLevelName);
		}
	}
}
