using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroEvents : MonoBehaviour
{

	//text fade in
	//cue audio
	//fade in instructions
	//fade out everything
	AudioSource knockingSound;

	public bool introOn = true;
	public GameObject canvas;
	public GameObject canvasMngr;
	public AudioSource doorSound;
	public Text title;
	public Text credits;
	public Text instructions;
	private Color startColor;
	private Color endColor;
	private Color endColor2;
	float FadeoutTime;
	float timer;
	bool timerDone;
	bool knockingDone = false;
	CanvasGroup alphaGroup;
	bool doorDone = false;

	float instructionAlpha;

	bool startClicked = false;

	bool playIntro = false;

	void Awake ()
	{
		//canvas.SetActive (true);
		//timer = 0.5f;
		//timerDone = false;
		alphaGroup = canvas.GetComponent<CanvasGroup> ();
		knockingSound = canvas.GetComponent<AudioSource> ();
		startColor = title.GetComponent<Text> ().color;
		endColor = new Color (1.0f, 0.8f, 0.3f, 0.9f);
		endColor2 = new Color (1.0f, 0.8f, 0.3f, 0.3f);
		instructionAlpha = 1f;
	}

	void prepIntro ()
	{
		if (introOn) {
			canvasMngr.SendMessage ("introOn");
			timer = 0.5f;
			timerDone = false;
			knockingDone = false;
			doorDone = false;
			alphaGroup.alpha = 1.0f;
		}
	}
	
	// Use this for initialization
	void Start ()
	{
		prepIntro ();
		playIntro = true;
	}

	public void clickStart ()
	{
		startClicked = true;
	}

	void reset (int day)
	{
		switch (day) {
		case 1:
			break;
		default:
			title.text = "";
			credits.text = "";
			prepIntro ();
			playIntro = true;
			break;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playIntro) {
			runIntro ();
		}



	}

	void runIntro ()
	{
		timer -= Time.deltaTime;
		Debug.Log (timer);
		if (timer <= 0 && !knockingDone) { //&& !knockingDone
			timerDone = true;
			//timer = 0;
		}
		FadeoutTime = Time.time * 0.3f;
		title.GetComponent<Text> ().color = Color.Lerp (startColor, endColor, FadeoutTime);
		credits.GetComponent<Text> ().color = Color.Lerp (startColor, endColor2, FadeoutTime);

		if (!startClicked) {
			instructions.GetComponent<Text> ().color = Color.Lerp (startColor, endColor2, FadeoutTime);
		}

		if (startClicked) {

			if (instructionAlpha > 0) {
				instructionAlpha -= 0.05f;
				Color newColor = instructions.GetComponent<Text> ().color;
				newColor.a = instructionAlpha;
				instructions.GetComponent<Text> ().color = newColor;
			}
		
			//knocking and housekeeping sound
			if (!knockingDone && timerDone && knockingSound.isPlaying == false) {
				//			Debug.Log (timerDone);
				knockingSound.Play ();
				timer = 6.0f;
				timerDone = false;
				knockingDone = true;
			}
		
			//door opening sound
			if (knockingDone && !doorDone && timer <= 0.5 && doorSound.isPlaying == false) {
				doorSound.Play ();
				doorDone = true;
			}
		
			//fade out UI
			if (timer <= 0 && knockingDone) {
				//Debug.Log ("Door sound" + doorSound.isPlaying);
				alphaGroup.alpha -= 0.04f;
			}

			if (alphaGroup.alpha <= 0) {
				Debug.LogWarning ("Intro complete!");
				canvasMngr.SendMessage ("introOff");
				playIntro = false;
			}
		}
	}


}
