using UnityEngine;
using System.Collections;

public class BathLightsOnOff : MonoBehaviour
{

	Light l;
	public float onIntensity = 1.3f;

	void Awake ()
	{
		l = GetComponentInChildren<Light> ();
	}

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void lightOn ()
	{
		l.intensity = onIntensity;
	}
	
	void lightOff ()
	{
		l.intensity = 0f;
	}
}
