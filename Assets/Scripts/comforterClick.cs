using UnityEngine;
using System.Collections;

public class comforterClick : MonoBehaviour
{

	public Transform comforter;
	public float rotationMax = 100f;
	public GameObject bedX;
	Cloth c;

	Vector3 makeBedPos;
	Quaternion makeBedRot;

	bool bedMade = false;

	void awake ()
	{


	}

	// Use this for initialization
	void Start ()
	{
		makeBedPos = comforter.position;
		makeBedRot = comforter.rotation;
		c = comforter.GetComponent<Cloth> ();

		messUpBed ();
	}

	void reset (int day)
	{
		messUpBed ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void onClick ()
	{

		c.enabled = false;
		StartCoroutine ("bedWait");
	}

	IEnumerator bedWait ()
	{

		yield return new WaitForSeconds (0.1f);
		comforter.position = makeBedPos;
		comforter.rotation = Quaternion.Euler (0f, 0f, 180f);
		//c.enabled = false;
		//yield return 0;
		c.enabled = true;
		Debug.LogWarning ("Bed Made");
		
		bedMade = true;
		bedX.SetActive (true);

	}

	void messUpBed ()
	{
		Vector3 randomPos = new Vector3 (0f, Random.Range (3, 4), 0f);

		float xRot = Random.Range (rotationMax * -1f, rotationMax);
		float yRot = Random.Range (rotationMax * -1f, rotationMax);
		float zRot = Random.Range (rotationMax * -1f, rotationMax);
		Quaternion randomRot = Quaternion.Euler (xRot, yRot, zRot);

		comforter.position += randomPos;
		comforter.rotation = randomRot;

		bedMade = false;
		bedX.SetActive (false);
	}
}
