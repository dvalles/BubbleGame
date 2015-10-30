using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

    SpriteRenderer[] spriteRens;
    TextMesh[] textMeshes;
    SpriteRenderer ren;
    public float fadeOutSpeed;
    public float fadeInSpeed;
    public string[] sayings;

	// Use this for initialization
	void Start () {
        spriteRens = transform.GetComponentsInChildren<SpriteRenderer>();
        textMeshes = transform.GetComponentsInChildren<TextMesh>();
        ren = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void StartFade()
    {
        StartCoroutine("FadeOut");
    }

    public void StartFadeIn()
    {
        Transform text = transform.Find("ReplayButton/GameOver/randMessage");
        //Debug.Log(text);
        text.GetComponent<TextMesh>().text = sayings[(int)Random.Range(0, sayings.Length - 1)];
        StartCoroutine("FadeIn");
    }

    IEnumerator FadeOut()
    {

        while (spriteRens[1].color.a > 0)
        {
            //Fade out Sprite Renderers
            foreach (SpriteRenderer spriteRen in spriteRens)
            {
                spriteRen.color = new Color(spriteRen.color.r, spriteRen.color.g, spriteRen.color.b, spriteRen.color.a - fadeOutSpeed);
                if (spriteRen.color.a < 0)
                    spriteRen.color = new Color(spriteRen.color.r, spriteRen.color.g, spriteRen.color.b, 0);
            }

            //Fade out TextMeshes
            foreach (TextMesh textMesh in textMeshes)
            {
                textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, textMesh.color.a - fadeOutSpeed);
                if (textMesh.color.a < 0)
                    textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);
            }

            //Fade out overlay
            ren.color = new Color(ren.color.r, ren.color.g, ren.color.b, ren.color.a - fadeOutSpeed);
            if (ren.color.a < 0)
                ren.color = new Color(ren.color.r, ren.color.g, ren.color.b, 0);


            yield return null;
        }
    }

    IEnumerator FadeIn()
    {
        while (spriteRens[1].color.a < 1)
        {
            //Fade out Sprite Renderers
            foreach (SpriteRenderer spriteRen in spriteRens)
            {
                spriteRen.color = new Color(spriteRen.color.r, spriteRen.color.g, spriteRen.color.b, spriteRen.color.a + fadeInSpeed);
                if (spriteRen.color.a > 1)
                    spriteRen.color = new Color(spriteRen.color.r, spriteRen.color.g, spriteRen.color.b, 1);
            }

            //Fade out TextMeshes
            foreach (TextMesh textMesh in textMeshes)
            {
                textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, textMesh.color.a + fadeInSpeed);
                if (textMesh.color.a > 1)
                    textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);
            }

            //Fade out overlay
            //ren.color = new Color(ren.color.r, ren.color.g, ren.color.b, ren.color.a + fadeInSpeed);
            if (ren.color.a > .396f)
                ren.color = new Color(ren.color.r, ren.color.g, ren.color.b, .396f);

           // Application.LoadLevel(Application.loadedLevelName);
            yield return null;
        }
    }


}
