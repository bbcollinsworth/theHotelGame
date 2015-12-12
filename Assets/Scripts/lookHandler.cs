using UnityEngine;
using System.Collections;

public class lookHandler : MonoBehaviour
{

	private bool onLookCalled = false;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		onLookCalled = false;
	}
	
	void OnLook ()
	{
		onLookCalled = true;
		
		
	}
}
