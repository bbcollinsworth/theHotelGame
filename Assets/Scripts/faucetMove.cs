using UnityEngine;
using System.Collections;

public class faucetMove : MonoBehaviour
{

	bool faucetOn;
	public ParticleSystem sinkWater;
	public ParticleSystem sinkSpray;

	public GameObject sinkX;

	Vector3 originalVect;
	Vector3 newVect;
	public AudioSource sinkSound;

	// Use this for initialization
	void Start ()
	{
		faucetOn = false;
		originalVect = transform.eulerAngles;
		newVect = new Vector3 (0f, 0f, -32.0f);
	}

	void reset (int day)
	{
		sinkX.SetActive (false);
	}
	
	// Update is called once per frame
	void onClick ()
	{
		//if (Input.GetMouseButtonUp (0)) {
		if (!faucetOn) {
			Debug.Log ("turning faucet on");
			transform.eulerAngles = Vector3.Lerp (originalVect, newVect, 1f);
			sinkWater.Play ();
			sinkSpray.Play ();
			sinkSound.Play ();
//				Transform newRotation = transform.Rotate(new Vector3(0f, 0f, -32.0f));
			faucetOn = true;
		} else {
			Debug.Log ("turning faucet off");
			transform.eulerAngles = Vector3.Lerp (newVect, originalVect, 1f);
			faucetOn = false;
			sinkSound.Stop ();
			sinkWater.Stop ();
			sinkSpray.Stop ();
			sinkX.SetActive (true);
		}
		//}
	}
}
