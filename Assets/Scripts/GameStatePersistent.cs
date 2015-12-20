using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStatePersistent : MonoBehaviour
{

	//public GameObject gameController;
	int dayCounter;

	[System.Serializable]

	public struct roomObjects
	{
		public string name;
		public GameObject item;
	};

	public roomObjects[] roomItems;

	//public string[] roomItemNames;
	//public Hashtable room = new Hashtable ();

	Dictionary<string,GameObject> room = new Dictionary<string, GameObject> () ;

	//private static GameStatePersistent instanceRef;


	void Awake ()
	{
		DontDestroyOnLoad (this);
		
		if (FindObjectsOfType (GetType ()).Length > 1) {
			Destroy (gameObject);
		}

		dayCounter = 0;
		/*
		if (instanceRef == null) {
			instanceRef = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			DestroyImmediate (this.gameObject);
		}
		*/
		//DontDestroyOnLoad (transform.gameObject);
		//dayCounter++;


		foreach (roomObjects i in roomItems) {
			room [i.name] = i.item;
		}


	}

	// Use this for initialization
	void Start ()
	{

		nextDay ();
		//dayCounter++;
		//Debug.LogWarning ("Day is " + dayCounter);
		//setupDay ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void nextDay ()
	{
		dayCounter++;
		Debug.LogWarning ("Day is " + dayCounter);
		setupDay ();
		//Application.LoadLevel (Application.loadedLevel);
	}

	void setupDay ()
	{

		foreach (roomObjects i in roomItems) {
			i.item.SendMessage ("reset", dayCounter, SendMessageOptions.DontRequireReceiver);
		}
		/*
		switch (dayCounter) {
		case 1:
		default:
			room ["lCurtain"].SendMessage ("reset", SendMessageOptions.DontRequireReceiver);
			room ["rCurtain"].SendMessage ("reset", SendMessageOptions.DontRequireReceiver);
			break;
		}
		*/
	}
}
