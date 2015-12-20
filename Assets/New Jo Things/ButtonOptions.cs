using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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
	GameObject b1;
	GameObject b2;
	static Button button1;
	static Button button2;
	static Text button1Text;
	static Text button2Text;
	public AudioSource voicemailAudio;




	[System.Serializable]
	
	public struct choiceOptions
	{
		public string name;
		public string option1Text;
		public string option2Text;
		public string function1;
		public string function2;
	};
	
	public choiceOptions[] choiceSetup;

	static Dictionary<string,choiceOptions> choice = new Dictionary<string, choiceOptions> () ;

	static Color transparent;
	static Color buttonPressed;
	float FadeoutTime;

	// Use this for initialization
	void Start ()
	{

		b1 = transform.Find ("Choice 1 Button").gameObject;
		b2 = transform.Find ("Choice 2 Button").gameObject;
		button1 = b1.GetComponent<Button> ();
		button2 = b2.GetComponent<Button> ();
		button1Text = b1.GetComponentInChildren<Text> ();
		button2Text = b2.GetComponentInChildren<Text> ();

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

		foreach (choiceOptions i in choiceSetup) {
			choice [i.name] = i;
		}
	}

	public static void showChoice (string item, GameObject clicked)
	{
		button1.image.color = buttonPressed;
		button2.image.color = buttonPressed;
		button1Text.text = choice [item].option1Text;
		button2Text.text = choice [item].option2Text;
		button1.onClick.RemoveAllListeners ();
		button2.onClick.RemoveAllListeners ();

		button1.onClick.AddListener (() => clicked.SendMessage (choice [item].function1));
		button2.onClick.AddListener (() => clicked.SendMessage (choice [item].function2));

		button1.onClick.AddListener (() => ButtonTextClear ());
		button2.onClick.AddListener (() => ButtonTextClear ());


		//button1.onClick.AddListener (() => choice [item].function1 ());

		/*switch (item) {
		case "phone":
			button1Text.text = choice [item].option1Text;
			button2Text.text = choice [item].option2Text;
			break;
		}*/
	}

	public void sendChoice (GameObject c, string functionToCall)
	{
		c.SendMessage ("functionToCall");
	}

	/*public static void addChoiceFunctions(void function1, void function2){
		button1.onClick.RemoveAllListeners();
		button2.onClick.RemoveAllListeners();
		button1.onClick.AddListener(()=> function1());
		button2.onClick.AddListener(()=> function2());
	}*/

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

	public static void ButtonTextClear ()
	{
		button1.image.color = transparent;
		button2.image.color = transparent;
		button1Text.text = "";
		button2Text.text = "";

	}
}
