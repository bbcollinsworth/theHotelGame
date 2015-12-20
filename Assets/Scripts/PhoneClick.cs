using UnityEngine;
using System.Collections;

public class PhoneClick : MonoBehaviour
{

	AudioSource dialTone;
	//public GameObject checklist;
	public AudioClip voicemailAlert;
	public AudioClip dialToneClip;
	public AudioSource voicemailAudio;
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
			dialTone.clip = dialToneClip;
			dialTone.loop = true;
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
				//ui.SendMessage ("showChoice", "phone");
				ButtonOptions.showChoice ("phone", transform.gameObject);
				//ButtonOptions.addChoiceFunctions (voiceMailListen, voiceMailIgnore);
			}
		} else {
			dialTone.Stop ();
			audioPlaying = false;
			phoneX.SetActive (true);
		}
	}

	public void voicemailListen ()
	{
		if (!voicemailAudio.isPlaying) {
			Debug.Log ("played phone audio");
			voicemailAudio.Play ();
			phoneX.SetActive (true);
			//UIText.text = "";
			//button1.image.color = transparent;
			//phoneClicked = false;
		}
	}

	public void voicemailIgnore ()
	{
		phoneX.SetActive (true);
		ButtonOptions.ButtonTextClear ();
	}
}
