using UnityEngine;
using System.Collections;

public class lightningScript : MonoBehaviour
{

	Light lightning;
	float flashTime;
	public float minBetwFlashes = 5f;
	public float maxBetwFlashes = 10f;
	bool newLightningAllowed;

	public AudioClip[] thunderSounds;
	AudioSource thunder;

	// Use this for initialization
	void Start ()
	{
		lightning = GetComponent<Light> ();
		thunder = GetComponent<AudioSource> ();
		lightning.enabled = false;
		flashTime = setRandomFlashTime ();
		newLightningAllowed = true;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Time.time >= flashTime && newLightningAllowed) {
			StartCoroutine ("lightningFlash");
			flashTime = setRandomFlashTime ();
			newLightningAllowed = false;
		}
	}

	public float setRandomFlashTime ()
	{
		float f = Time.time + Random.Range (minBetwFlashes, maxBetwFlashes);
		return f;
	}

	IEnumerator lightningFlash ()
	{
		//lightning.SetActive (true);
		Debug.LogWarning ("Lightning CoRoutine Started");
		int randomThunder = Random.Range (0, thunderSounds.Length);
		thunder.clip = thunderSounds [randomThunder];

		float thunderWait = Random.Range (0, 5) + 0.5f;

		//set lighting intensity to be higher the less the thunder time is
		lightning.intensity = 1.5f + (5.5f - thunderWait) * 0.5f;

		lightning.enabled = true;
		while (lightning.intensity > 0.1f) {
			yield return 0;
			lightning.intensity *= 0.9f;
		}
		//float flashTime = Random.Range (1, 3) * 0.1f;
		//yield return new WaitForSeconds (flashTime);
		lightning.enabled = false;


		yield return new WaitForSeconds (thunderWait);
		Debug.LogWarning ("Playing thunder");
		thunder.Play ();
		while (thunder.isPlaying) {
			yield return 0;
		}

		newLightningAllowed = true;
		Debug.LogWarning ("Lightning CoRoutine Finished");
		yield break;

	}
}

