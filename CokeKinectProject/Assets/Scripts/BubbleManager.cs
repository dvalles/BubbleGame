using UnityEngine;
using System.Collections;
//using UnityEngine.UI;

public class BubbleManager : MonoBehaviour {

	public GameObject bodyView;
    public Sprite handSprite;
    public Sprite bubbleSprite;
	private BodySourceView body;
    private SpriteRenderer spriteRen;
    private BubbleGrow bubbleGrow;
	public GameObject targetCam;
	private Camera camera;
	public float speed;
    public GameObject overlayStart;
    //public GameObject overlayEndPrefab;
    public SpriteRenderer buttonStrokeEnd;
    public SpriteRenderer buttonStrokeStart;
    public GameObject overlayEnd;
    public GameObject replayButton;
    public GameObject startButton;
    public GameObject deathSphere;
    public GameObject particles;
    public GameObject timer;
    private Timer timerCon;
	private BubbleGrow bubblegrow;
    public int fadeWait;
    private int fadeCount = 0;
    private int fadeCountReplay = 0;
    public IceCubeSpawn iceSpawn;
    AudioSource[] touchStraw;

    //Variables that have very small use
    private bool bubblePlaced = false;
    public int invulFlash = 10;
    private bool died = false;
    private int invulCount = 0;
    public int invulWait = 100;
    private bool invulCounting = false;
    public int dontFlashTill = 0;
    private bool endVisible = false;
    private bool startVisible = true;
    public bool restartCounting = false;

    

	// Use this for initialization
	void Start () {
        bubbleGrow = GetComponent<BubbleGrow>();
        bubbleGrow.enabled = false;
        transform.GetComponentInChildren<ParticleSystem>().enableEmission = false;
		body = bodyView.GetComponent<BodySourceView> ();
        spriteRen = GetComponent<SpriteRenderer>();
        spriteRen.sprite = handSprite;
		camera = targetCam.GetComponent<Camera> ();
		bubblegrow = GetComponent<BubbleGrow>();
        touchStraw = GetComponents<AudioSource>();
        timerCon = timer.GetComponent<Timer>();
        replayButton.GetComponent<BoxCollider2D>().enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (body){
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, body.getHandPosition(), step);
            //transform.position = Vector3.MoveTowards(transform.position, camera.ScreenToWorldPoint(Input.mousePosition), step);
            //transform.position = camera.ScreenToWorldPoint(Input.mousePosition);
            if (spriteRen.sprite == bubbleSprite)
                transform.position = new Vector3 (transform.position.x, transform.position.y, -13f);
            if (spriteRen.sprite == handSprite)
                transform.position = new Vector3(transform.position.x, transform.position.y, -18.5f);
        }

        if (invulCounting)
        {
            invulCount++;
            if (invulCount > dontFlashTill)
            {
                if (invulCount % invulFlash >= invulFlash / 2)
                    spriteRen.sprite = bubbleSprite;
                else
                    spriteRen.sprite = null;
            }
        }

        if (invulCount > invulWait)
        {
            spriteRen.sprite = bubbleSprite;
            invulCount = 0;
            timerCon.countDown = true;
            invulCounting = false;
            GetComponent<CircleCollider2D>().enabled = true;
        }
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
        if (spriteRen.sprite == bubbleSprite)
        {
            if (collider.gameObject.tag == "IceCube")
            {
                //died = true;
                touchStraw[1].Play();
                //Instantiate(deathSphere, transform.position, deathSphere.transform.rotation);
                Instantiate(particles, transform.position, particles.transform.rotation);
                timerCon.countDown = false;
                //overlayEnd = Instantiate(overlayEndPrefab, overlayEndPrefab.transform.position, overlayEndPrefab.transform.rotation);
                overlayEnd.GetComponent<Fade>().StartFadeIn();
                restartCounting = true;
                //restartCount = 0;
                // StartCoroutine("waitAndFadeIn");
                transform.GetComponentInChildren<ParticleSystem>().enableEmission = false;
                spriteRen.sprite = handSprite;
                iceSpawn.shouldSpawn = false;
                bubbleGrow.enabled = false;
                bubblePlaced = false;
                replayButton.GetComponent<BoxCollider2D>().enabled = true;
                transform.localScale = new Vector3(0.266f, 0.266f, 0.266f);
                endVisible = true;
            }
            if (collider.gameObject.tag == "Straw")
            {
                bubblegrow.setShrinking(true);
                touchStraw[0].Play();
            }
        }
        else
        {
            if (collider.gameObject.tag == "replayButton" && endVisible)
            {
                buttonStrokeEnd.color = new Color(1f, 1f, 1f, .5f);
            }

            if (collider.gameObject.tag == "startButton" && startVisible)
            {
                buttonStrokeStart.color = new Color(1f, 1f, 1f, .5f);
            }
        }
	}

    void OnTriggerStay2D(Collider2D collider) {
        if (spriteRen.sprite == handSprite)
        {
            if (collider.gameObject.tag == "startButton")
            {
                fadeCount++;
                if (fadeCount > fadeWait)// && !bubblePlaced)
                {
                    buttonStrokeStart.color = new Color(1f, 1f, 1f, 0f);
                    startVisible = false;
                    overlayStart.GetComponent<Fade>().StartFade();
                    spriteRen.sprite = bubbleSprite;
                    bubbleGrow.enabled = true;
                    transform.GetComponentInChildren<ParticleSystem>().enableEmission = true;
                    timerCon.countDown = true;
                    startButton.GetComponent<BoxCollider2D>().enabled = false;
                    //Destroy(overlayStart, 1.5f);
                    transform.position = new Vector3(0, -5.8f, transform.position.z);
                    //bubblePlaced = true;
                    iceSpawn.shouldSpawn = true;
                }
            }

            if (collider.gameObject.tag == "replayButton")// && died && !bubblePlaced)
            {
                fadeCountReplay++;
                if (fadeCountReplay > fadeWait + 20)
                {
                    //overlayEnd
                    restartCounting = false;
                    buttonStrokeEnd.color = new Color(1f, 1f, 1f, 0f);
                    endVisible = false;
                    overlayEnd.GetComponent<Fade>().StartFade();
                    spriteRen.sprite = bubbleSprite;
                    bubbleGrow.enabled = true;
                    transform.GetComponentInChildren<ParticleSystem>().enableEmission = true;
                    //Destroy(overlayStart, 1.5f);
                    transform.position = new Vector3(0, -5.8f, transform.position.z);
                   // bubblePlaced = true;
                    iceSpawn.shouldSpawn = true;
                    timerCon.Reset();
                    replayButton.GetComponent<BoxCollider2D>().enabled = false;
                   // died = false;
                    fadeCountReplay = 0;
                    invulCount = 0;
                    invulCounting = true;
                    GetComponent<CircleCollider2D>().enabled = false;
                }
            }
        }
    }

    
	
	void OnTriggerExit2D(Collider2D collider)
	{
        if (spriteRen.sprite == bubbleSprite)
        {
            if (collider.gameObject.tag == "Straw")
            {
                bubblegrow.setShrinking(false);
            }
        }

        if (spriteRen.sprite == handSprite)
        {
            if (collider.gameObject.tag == "startButton")
            {
                fadeCount = 0;
            }

            if (collider.gameObject.tag == "startButton" && startVisible)
            {
                buttonStrokeStart.color = new Color(1f, 1f, 1f, 0f);
            }

            if (collider.gameObject.tag == "replayButton")
            {
                fadeCountReplay = 0;
            }

            if (collider.gameObject.tag == "replayButton" && endVisible)
            {
                buttonStrokeEnd.color = new Color(1f, 1f, 1f, 0f);
            }

        }
	}

    IEnumerator waitAndFadeIn()
    {
        //for (int x = 0; x < 2; x++)
       // {
            yield return new WaitForSeconds(1f);
            overlayEnd.GetComponent<Fade>().StartFadeIn();
        //}
    }
	
}
