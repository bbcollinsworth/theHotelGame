using UnityEngine;
using System.Collections;

public class dayChange : MonoBehaviour
{

	public GameObject skyPanel;
	public Transform sunOrigin;
	public GameObject lightning;

	public GameObject[] lights;
	public Texture[] skies;
	
	Material skyMat;


	// Use this for initialization
	void Start ()
	{
		skyMat = skyPanel.GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void reset (int day)
	{
		activateNewSun (day, lights);
		changeTexture (day, skies);

		switch (day) {
		case 3:
			lightning.SetActive (true);
			break;
		default:
			lightning.SetActive (false);
			break;
		}

		/*switch (day) {
		case 2:
			activateNew (day, lights);
			activateNew (day, skies);
			for (int i = 0; i<lights.Length; i++){

				if (i == day-1){
					lights[i].SetActive(true);
				} else {
					lights[i].SetActive(false);
				}
			}
			break;
		case 1:
		default:
			activateNew (day, lights);
			//activateNew (day, skies);

			break;
		}*/
	}

	public void activateNewSun (int d, GameObject[] items)
	{
		//GameObject activeLight;

		//make sure light doesn't get switched back off
		//turn off all lights first, then turn on this light
		for (int i = 0; i<items.Length; i++) {
			items [i].SetActive (false);
		}

		items [d - 1].SetActive (true);

		sunOrigin.position = items [d - 1].transform.forward * -1f * 300f;
			
		/*if (i == d - 1) {
				items [i].SetActive (true);
				activeLight = items[i];
			} else if (items[i] == activeLight) {

			} else {
				items [i].SetActive (false);
			}
		}*/
	}

	public void changeTexture (int d, Texture[] items)
	{
		skyMat.mainTexture = items [d - 1];

		/*for (int i = 0; i<items.Length; i++) {
			
			if (i == d - 1) {
				skyMat. items [i];
			} else {
				items [i].SetActive (false);
			}
		}*/
	}
}
