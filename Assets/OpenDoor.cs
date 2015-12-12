using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour
{

	bool rotateCalled = false;
	float rotateTargetF = 90f;
	float rotateAngle = 0f;
	Quaternion rotateTargetQ;// = Quaternion.Euler (0f, rotateTargetF, 0f);

	//Quaternion rotateTargetQ = Quaternion.Euler (0f, 0f, 0f);
	//Quaternion rotateTarget;// = Quaternion.Euler (0f, rotateAmount, 0f);
	// Use this for initialization
	void Start ()
	{
		rotateTargetQ = Quaternion.Euler (0f, rotateTargetF, 0f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (rotateCalled) {
			rotateDoor ();
		}

	}

	void onClick ()
	{
		rotateCalled = true;
	}

	void rotateDoor ()
	{

		float transformY = transform.rotation.eulerAngles.y;
		if (Mathf.Abs (transform.rotation.eulerAngles.y - rotateTargetQ.y) > 0.01) {
			transform.rotation = rotateTargetQ;
			Debug.Log (Mathf.Abs (transformY - rotateTargetQ.y));
			Debug.Log ("Still rotating...");
			//if (Mathf.Abs (rotateAngle - rotateTarget) > 0.01) {
			//rotateAngle = Mathf.LerpAngle (0f, rotateTarget, 0.2f);
			//transform.Rotate (Vector3.up * rotateAngle);
		} else {
			//if (Mathf.Abs (rotateAngle - rotateTarget) < 0.1) {
			//rotateAngle = 0;
			//transform.Rotate (Vector3.up * rotateTarget);
			rotateCalled = false;
			reverseRotateTarget ();

		}




	}

	void reverseRotateTarget ()
	{
		if (rotateTargetF != 0f) {
			rotateTargetF = 0f;
			Debug.Log ("Rotate Target F changed to: " + rotateTargetF);
		} else {
			rotateTargetF = 90f;
			Debug.Log ("Rotate Target F changed to: " + rotateTargetF);
		}
		Quaternion rotateTargetQ = Quaternion.Euler (0f, rotateTargetF, 0f);
		//rotateTarget *= -1;
	}
}
