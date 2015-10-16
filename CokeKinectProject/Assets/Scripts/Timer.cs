using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float timeLeft;
    Text textC;
    public bool countDown = false;
   // public GameObject endGlass;
    //public GameObject bubble;
    //public float speed = 5;

	// Use this for initialization
	void Start () {
        textC = GetComponent<Text>();
        textC.text = makeString(timeLeft);
	}
	
	// Update is called once per frame
	void Update () {
        if (countDown)
        {
            timeLeft = timeLeft + Time.deltaTime;
            textC.text = makeString(timeLeft);
            //float timePrint = Mathf.Ceil(timeLeft);
            // Debug.Log(timePrint);
        }
       // if (timeLeft <= 0)
       // {
         //   countDown = false;
         //   Vector3 vectorNew = new Vector3(endGlass.transform.position.x, -2.25f, endGlass.transform.position.z);
         //   endGlass.transform.position = Vector3.MoveTowards(endGlass.transform.position, vectorNew, speed*Time.deltaTime);
          //  bubble.GetComponent<BubbleManager>()
       // }

	}

    public void Reset()
    {
        timeLeft = 0f;
        textC.text = makeString(timeLeft);
    }

    string makeString(float time)
    {
        int timeInt = Mathf.CeilToInt(time);
        int seconds = timeInt % 60;
        int secondsA = seconds / 10;
        int secondsB = seconds % 10;

        int minutes = timeInt / 60;
        int minutesA = minutes / 10;
        int minutesB = minutes % 10;
        return minutesA + " " + minutesB + " : " + secondsA + " " + secondsB;

    }
}
