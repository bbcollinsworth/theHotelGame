using UnityEngine;
using System.Collections;

public class mainDoorClick : MonoBehaviour
{

	public GameObject gameState;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void onClick ()
	{
		gameState.SendMessage ("nextDay", SendMessageOptions.DontRequireReceiver);
	}
}
