using UnityEngine;
using System.Collections;

public class triggerAction : MonoBehaviour
{

	public float interactRange = 4;

	public string functionToCallOnLook = "OnLook";

	bool inTrigger = false;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//should be set to camera look direction
		Ray sightRay = new Ray (transform.position, transform.forward);
		
		RaycastHit hit = new RaycastHit ();

		if (Physics.Raycast (sightRay, out hit, interactRange)) {
			hit.transform.SendMessage (functionToCallOnLook, SendMessageOptions.DontRequireReceiver);
		}

		//if (inTrigger) {

		//}
	}

	//void OnTriggerEnter ()
	//{
	//	inTrigger = true;
	//}
}
