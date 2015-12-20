using UnityEngine;
using System.Collections;

public class photoControl : MonoBehaviour
{
	public GameObject[] photos;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void reset (int day)
	{
		switch (day) {
		case 2:
			foreach (GameObject photo in photos) {
				photo.SetActive (true);
			}
			break;
		case 1:
		default:
			foreach (GameObject photo in photos) {
				photo.SetActive (false);
			}
			break;
		}
	}
}
