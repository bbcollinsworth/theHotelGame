using UnityEngine;
using System.Collections;

public class MoneyScript : MonoBehaviour
{

	//public GameObject ui;

	public AudioSource moneyTakeSound;

	// Use this for initialization
	void Start ()
	{
		//ui = GameObject.Find ("Canvas-interact");

		//moneyTakeSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void reset (int day)
	{
		switch (day) {
		case 1:
			gameObject.SetActive (true);
			break;
		default:
			gameObject.SetActive (false);
			break;
		}
	}

	void onClick ()
	{
		//ui.SendMessage ("showChoice", "money");
		ButtonOptions.showChoice ("money", transform.gameObject);
	}

	void takeMoney ()
	{
		/*Transform[] moneyPieces = GetComponentsInChildren<Transform>();

		foreach(Transform m in moneyPieces){

		}*/

		//StartCoroutine ("moneyTaking");

		moneyTakeSound.Play ();
		gameObject.SetActive (false);
	}

	IEnumerator moneyTaking ()
	{
		moneyTakeSound.Play ();
		while (moneyTakeSound.isPlaying) {
			yield return 0;
		}
		gameObject.SetActive (false);
	}
}
