using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour
{

	public bool mouseHEnabled = false;
	public float moveUnit;
	public float rotateUnit;
	public float mouseRotateUnit = 1f;
	Vector3 startPos;
	Quaternion startRot;

	Vector3 moveVector;
	Vector3 rotVector;

	Rigidbody body;

	public Transform mainCam;
	
	public float moveZoneMin = 0.3f;
	public float maxRot = 50f;
	public float sensitivity = 0.1f;
	
	float centeredMouseY, centeredMouseX = 0f;
	float rotV, rotH = 0f;
	bool looking = false;

	// Use this for initialization
	void Start ()
	{
		body = GetComponent<Rigidbody> ();
		startPos = transform.position;
		startRot = transform.rotation;
	}

	void reset (int day)
	{
		transform.position = startPos;
		transform.rotation = startRot;
	}

	void mouseRot ()
	{
		//float rotV = map (Mathf.Abs (centeredMouseY), moveZoneMin, 1f, 0, rotateUnit);

		//transform.
	}
	
	// Update is called once per frame
	//void FixedUpdate ()
	void FixedUpdate ()
	{

		if (mouseHEnabled) {

			centeredMouseX = (Input.mousePosition.x / Screen.width - 0.5f) * 2f;
			//centeredMouseY = (Input.mousePosition.y / Screen.height - 0.5f) * 2f;

			if (Mathf.Abs (centeredMouseX) > moveZoneMin) {
				rotH = map (Mathf.Abs (centeredMouseX), moveZoneMin, 1f, 0, mouseRotateUnit);

				if (centeredMouseX < 0) {
					rotH *= -1f;
				}
			} else if (rotH > 0.01f) {
				rotH *= 0.9f;
			} else {
				rotH = 0f;
			}
		}

		/*if (Mathf.Abs (centeredMouseY) > moveZoneMin) {
			rotV = map (Mathf.Abs (centeredMouseY), moveZoneMin, 1f, 0, rotateUnit);

			if (centeredMouseY > 0) {
				rotV *= -1f;
			}
		} else if (rotV > 0.01) {
			rotV *= 0.9f;
		} else {
			rotV = 0f;
		}*/

		Vector3 mouseVector = Vector3.up * rotH; //new Vector3 (0f, rotH, 0f);


		if (Input.GetKey (KeyCode.UpArrow)) {
			moveVector = transform.forward * moveUnit;
			//Debug.Log ("Up arrow key pressed.");
			//body.AddForce (transform.forward * moveUnit);
			//transform.position += moveVector;//0.1f;//transform.forward * moveUnit;

		} else if (Input.GetKey (KeyCode.DownArrow)) {
			//body.AddForce (transform.forward * moveUnit * -1f);
			moveVector = transform.forward * moveUnit * -1f;
			//transform.position += moveVector;
		} else if (moveVector.magnitude > 0.01f) {
			moveVector *= 0.9f;
		} else {
			moveVector *= 0;
		}

		transform.position += moveVector;// * Time.deltaTime;

		if (rotH != 0) {
			rotVector = mouseVector;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			rotVector = Vector3.up * rotateUnit * -1f;
			//body.AddTorque (Vector3.up * rotateUnit * -1f);
			//transform.Rotate (Vector3.up * rotateUnit * -1f);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			rotVector = Vector3.up * rotateUnit;
			//body.AddTorque (Vector3.up * rotateUnit);
			//transform.Rotate (Vector3.up * rotateUnit);
		} else if (rotVector.magnitude > 0.01f) {
			rotVector *= 0.9f;
		} else {
			rotVector *= 0;
		}

		transform.Rotate (rotVector);// * Time.deltaTime);// + mouseVector);
	}


	float map (float varToMap, float varMin, float varMax, float mapToMin, float mapToMax)
	{
		var mappedValue = mapToMin + (mapToMax - mapToMin) * ((varToMap - varMin) / (varMax - varMin));
		return mappedValue;
	}
}
