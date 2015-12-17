using UnityEngine;
using System.Collections;

public class introOnOff : MonoBehaviour
{

	public GameObject introCanvas;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void introOn ()
	{
		introCanvas.SetActive (true);
	}

	void introOff ()
	{
		introCanvas.SetActive (false);
	}
}
