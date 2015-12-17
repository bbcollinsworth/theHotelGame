using UnityEngine;
using System.Collections;

public class LightSwitchClickAction : MonoBehaviour
{

	public bool lightsOn = false;
	public GameObject[] linkedLights;
	AudioSource switchSound;
	//public AudioClip switchOff;
	// Use this for initialization
	void Start ()
	{
		switchSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void onClick ()
	{

		//transform.Rotate (Vector3.right * 180f);

		if (lightsOn) {
			switchSound.Play ();
			changeLights ("lightOff");
		} else {
			switchSound.Play ();
			changeLights ("lightOn");
		}

		//lightsOn = !lightsOn;
	}

	void reset (int day)
	{
		switch (day) {
		case 1:
		default:
			if (lightsOn) {
				changeLights ("lightOff");
			}
			break;
		}

	}

	void changeLights (string functionToCall)
	{
		transform.Rotate (Vector3.right * 180f);
		foreach (GameObject light in linkedLights) {
			light.SendMessage (functionToCall, SendMessageOptions.DontRequireReceiver);
		}
		lightsOn = !lightsOn;
	}
}
