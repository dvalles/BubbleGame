using UnityEngine;
using System.Collections;

public class FallBG : MonoBehaviour
{
    //public float scaleGap
    private float speed;
    private Rigidbody2D body;
    // Use this for initialization
    void Start()
    {
        float scaler = 1 + Time.time / 90;
        speed = Random.Range(.3f, 1.1f);
        body = GetComponent<Rigidbody2D>();
        float scale = Random.Range(0.45905570f, .8590557f);
        transform.localScale = new Vector3(scale, scale, scale);
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector3(0f, -speed, 0f);
    }
}
