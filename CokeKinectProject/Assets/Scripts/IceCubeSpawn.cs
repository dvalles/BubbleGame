using UnityEngine;
using System.Collections;

public class IceCubeSpawn : MonoBehaviour {

	public GameObject[] iceCubes;
    public GameObject[] iceCubesBG;
	private float ySpawn = 6.14f;
	private float zSpawn = -12.25f;
    private float zSpawnBG = -10.14f;
    public bool shouldSpawn = false;


	// Use this for initialization
	void Start () {
		//Random.seed = (int) Random.Range (Mathf.NegativeInfinity, Mathf.Infinity);
		StartCoroutine ("spawnIce");
        StartCoroutine("spawnIceBG");
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator spawnIce ()
	{
		while (true) {
            if (shouldSpawn)
            {
                int index = (int)Random.Range(0f, 17f);
                GameObject iceCube = iceCubes[index];
                Vector3 startPos = new Vector3(Random.Range(-2.73f, 2.73f), ySpawn, zSpawn);
                Object iceCubeClone = Instantiate(iceCube, startPos, iceCube.transform.rotation);
                Destroy(iceCubeClone, 45f);
                //yield return new WaitForSeconds (2f);
            }
            yield return new WaitForSeconds(Random.Range(.1f, 4f));
        }
    }

    IEnumerator spawnIceBG()
    {
        while (true)
        {
            int index = (int)Random.Range(0f, 6f);
            GameObject iceCube = iceCubesBG[index];
            Vector3 startPos = new Vector3(Random.Range(-2.73f, 2.73f), ySpawn, zSpawnBG);
            Object iceCubeClone = Instantiate(iceCube, startPos, iceCube.transform.rotation);
            Destroy(iceCubeClone, 45f);
            yield return new WaitForSeconds(Random.Range(.1f, 3f));
            //yield return new WaitForSeconds (2f);
        }
    }

}
