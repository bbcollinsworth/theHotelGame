using UnityEngine;
using System.Collections;

public class RoomLampsOnOff : MonoBehaviour
{

	Light l;
	public Material mat;
	Color baseColor;

	void Awake ()
	{
		l = GetComponentInChildren<Light> ();
		//baseColor = new Color (1f, 1f, 1f);
		baseColor = mat.GetColor ("_EmissionColor"); //!important -- must get while light is on!!
	}

	// Use this for initialization
	void Start ()
	{
		/*
		l = GetComponentInChildren<Light> ();
		//baseColor = new Color (1f, 1f, 1f);
		baseColor = mat.GetColor ("_EmissionColor"); //!important -- must get while light is on!!
		*/
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void lightOn ()
	{
		l.intensity = 1.3f;
		changeEmissive (1f);
	}

	void lightOff ()
	{
		l.intensity = 0f;
		changeEmissive (0.01f);
	}

	void changeEmissive (float intensity)
	{
		//Color tempColor = mat.GetColor ("_EmissionColor");

		Color newColor = new Color (1f, 1f, 1f) * Mathf.LinearToGammaSpace (intensity);

		mat.SetColor ("_EmissionColor", newColor);
	}
}
