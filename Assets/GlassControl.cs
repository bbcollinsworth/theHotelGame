using UnityEngine;
using System.Collections;

public class GlassControl : MonoBehaviour
{

	public GameObject fixedGlass;
	public GameObject brokenGlass;


	BoxCollider clickTrigger;

	// Use this for initialization
	void Start ()
	{
		//clickTrigger = GetComponent<BoxCollider> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void reset (int day)
	{
		switch (day) {
		case 3:
			gameObject.layer = 8;
			fixedGlass.SetActive (false);
			brokenGlass.SetActive (true);
			break;
		default:
			gameObject.layer = 0;
			fixedGlass.SetActive (true);
			brokenGlass.SetActive (false);
			break;
		}
	}

	void onClick ()
	{
		ButtonOptions.showChoice ("brokenGlass", transform.gameObject);
	}

	void replace ()
	{
		fixedGlass.SetActive (true);
		brokenGlass.SetActive (false);
	}
}
