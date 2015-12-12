using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonOptions : MonoBehaviour
{
	public Text UIText;
	bool phoneClicked;
	bool suitcaseClicked;
	bool trashClicked;
	bool suitcaseMoved;
	bool suitcaseExamined;
	bool trashEmptied;
	bool trashExamined;
	public AudioSource voicemailAudio;
	public Button button1;
	public Button button2;
	public Text button1Text;
	public Text button2Text;
	Color transparent;
	Color buttonPressed;
	float FadeoutTime;

	// Use this for initialization
	void Start ()
	{
		phoneClicked = false;
		suitcaseClicked = false;
		trashClicked = false;
		suitcaseMoved = false;
		suitcaseExamined = false;
		trashEmptied = false;
		trashExamined = false;
		transparent = new Color (1f, 1f, 1f, 0f);
		buttonPressed = new Color (1f, 1f, 1f, 0.4f);
		button1.image.color = transparent;
		button2.image.color = transparent;
	}

	void showPhoneChoice ()
	{
		button1.image.color = buttonPressed;
		button1Text.text = "LISTEN TO VOICE MESSAGE";
		
		button2.image.color = buttonPressed;
		button2Text.text = "IGNORE";
		
		//UIText.text = "Press 1 to listen to voice message";
		phoneClicked = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//trigger phone UI text

		if (Input.GetKeyUp (KeyCode.P)) {
			button1.image.color = buttonPressed;
			button1Text.text = "LISTEN TO VOICE MESSAGE";

			button2.image.color = buttonPressed;
			button2Text.text = "IGNORE";

			//UIText.text = "Press 1 to listen to voice message";
			phoneClicked = true;
		}

		if (phoneClicked) {
			button1.onClick.AddListener (() => voicemailListen ());
			button2.onClick.AddListener (() => voicemailIgnore ());
		}

		//trigger voicemail audio
		if (phoneClicked) {
			if (Input.GetKeyUp (KeyCode.Alpha1) && !voicemailAudio.isPlaying) {
				Debug.Log ("played phone audio");
				voicemailAudio.Play ();
				UIText.text = "";
				button1.image.color = transparent;
				phoneClicked = false;
			}
		}

		//suitcase options
		if (Input.GetKeyUp (KeyCode.S)) {
			if (!suitcaseMoved) {
				button1.image.color = buttonPressed;
				button1Text.text = "MOVE SUITCASE";
			}

			if (!suitcaseExamined) {
				button2.image.color = buttonPressed;
				button2Text.text = "EXAMINE SUITCASE";
			}

			suitcaseClicked = true;
		}

		if (suitcaseClicked) {
			button1.onClick.AddListener (() => MoveSuitcase ());
			button2.onClick.AddListener (() => ExamineSuitcase ());
		}

		//trash options
		if (Input.GetKeyUp (KeyCode.T)) {
			if (!trashEmptied) {
				button1.image.color = buttonPressed;
				button1Text.text = "THROW AWAY TRASH";
			}

			if (!trashExamined) {
				button2.image.color = buttonPressed;
				button2Text.text = "EXAMINE TRASH";
			}

			trashClicked = true;
		}

		if (trashClicked) {
			button1.onClick.AddListener (() => EmptyTrash ());
			button2.onClick.AddListener (() => ExamineTrash ());
		}
	}

	void MoveSuitcase ()
	{
		Debug.Log ("YES button1 move suitcase!");
		ButtonTextClear ();
		suitcaseMoved = true;
	}

	void ExamineSuitcase ()
	{
		Debug.Log ("YES button2 examining suitcase!");
		ButtonTextClear ();
		suitcaseExamined = true;
	}

	void EmptyTrash ()
	{
		ButtonTextClear ();
		trashEmptied = true;
	}

	void ExamineTrash ()
	{
		ButtonTextClear ();
		trashExamined = true;
	}

	void voicemailListen ()
	{
		if (!voicemailAudio.isPlaying) {
			Debug.Log ("played phone audio");
			voicemailAudio.Play ();
			UIText.text = "";
			button1.image.color = transparent;
			phoneClicked = false;
		}
		ButtonTextClear ();
		//trashExamined = true;
	}

	void voicemailIgnore ()
	{
		ButtonTextClear ();
		//trashExamined = true;
	}

	void ButtonTextClear ()
	{
		button1.image.color = transparent;
		button2.image.color = transparent;
		button1Text.text = "";
		button2Text.text = "";

	}
}
