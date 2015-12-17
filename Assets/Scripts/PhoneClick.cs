using UnityEngine;
using System.Collections;

public class PhoneClick : MonoBehaviour
{

	AudioSource dialTone;
	//public GameObject checklist;
	public AudioClip voicemailAlert;
	public GameObject ui;
	public GameObject phoneX;
	int d;
	bool audioPlaying = false;
	// Use this for initialization
	void Start ()
	{
		dialTone = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void reset (int day)
	{
		d = day;
		switch (day) {
		case 2:
			dialTone.clip = voicemailAlert;
			dialTone.loop = false;
			break;
		case 1:
		default:
			break;
		}

		phoneX.SetActive (false);
	}

	void onClick ()
	{
		if (!dialTone.isPlaying) {
			audioPlaying = true;
			dialTone.Play ();
			if (d == 2) {
				ui.SendMessage ("showPhoneChoice");
			}
		} else {
			dialTone.Stop ();
			audioPlaying = false;
			phoneX.SetActive (true);
		}
	}
}
