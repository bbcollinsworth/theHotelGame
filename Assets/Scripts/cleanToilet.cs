using UnityEngine;
using System.Collections;

public class cleanToilet : MonoBehaviour
{
	public GameObject toiletLid;
	public GameObject toiletWater;
	public GameObject flushingWater;

	public GameObject toiletX;

	bool lidUp = false;
	Renderer rend;
	Renderer rend2;
	public Color color = new Color (0.2F, 0.5F, 0.9F);
	Color originalColor;
	float timer;
	bool flushing;
	AudioSource toiletFlush;

	bool lidUpCalled, blueCalled, flushCalled, lidDownCalled;

	void Start ()
	{
		rend = toiletWater.GetComponent<Renderer> ();
		rend2 = flushingWater.GetComponent<Renderer> ();
		timer = 10;
		toiletFlush = GetComponent<AudioSource> ();
	}

	void onClick ()
	{
		if (!lidUpCalled) {
			lidUpCalled = true;
		} else if (!blueCalled) {
			blueCalled = true;
		} else if (!flushCalled) {
			flushCalled = true;
			toiletFlush.Play ();
		} else {
			lidDownCalled = true;
			toiletX.SetActive (true);
		}
	}

	void reset (int day)
	{
		lidUpCalled = false;
		blueCalled = false;
		flushCalled = false;
		lidDownCalled = false;
		lidUp = false;
		toiletX.SetActive (false);
	}

	// Update is called once per frame
	void Update ()
	{

		if (lidUp) {
			toiletLid.transform.rotation = Quaternion.Euler (-77, 90, 0);
		} else {
			toiletLid.transform.rotation = Quaternion.Euler (0, 90, 0);
		}

		if (lidUpCalled) {
			lidUp = true;

		}

		if (blueCalled) {
			rend.material.shader = Shader.Find ("Particles/Additive");
			originalColor = rend.material.GetColor ("_TintColor");
//			Debug.Log (rend.material.GetColor);
			rend.material.SetColor ("_TintColor", color);
		}

		if (flushCalled) {
			timer = 10;
			flushing = true;
			toiletWater.SetActive (false);
			flushingWater.SetActive (true);
			//create a timer
		}

		if (flushing) {
			if (timer <= 0) {
				toiletWater.SetActive (true);
				flushingWater.SetActive (false);
				flushing = false;
				Debug.Log (flushing);
				rend.material.SetColor ("_TintColor", originalColor);
				toiletFlush.Stop ();

			} else {
				Debug.Log (Time.time);
				rend2.material.shader = Shader.Find ("Particles/Additive");
				float time = (Time.time * 0.1f);
				rend2.material.SetColor ("_TintColor", Color.Lerp (color, originalColor, time));
				flushingWater.transform.rotation = Quaternion.Euler (0, 90, 0);
				timer -= Time.deltaTime;
			}
		}

		if (lidDownCalled) {
			
			lidUp = false;
			
		}

	}

//click on toilet lid to lift (x rotation: -77)


//click on water to apply blue cleaner (turn water blue)
//let sit for X secs
//click on toilet bowl to scrub (trigger noise)
//push button on toilet to flush

}