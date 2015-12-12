using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour
{
	public float moveUnit;
	public float rotateUnit;
	Vector3 startPos;
	Quaternion startRot;

	Rigidbody body;

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
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetKey (KeyCode.UpArrow)) {
			Debug.Log ("Up arrow key pressed.");
			body.AddForce (transform.forward * moveUnit);
			//transform.position.z += 0.1f;//transform.forward * moveUnit;

		} else if (Input.GetKey (KeyCode.DownArrow)) {
			body.AddForce (transform.forward * moveUnit * -1f);
			//transform.position += transform.forward * moveUnit * -1f;
		} 

		if (Input.GetKey (KeyCode.LeftArrow)) {
			body.AddTorque (Vector3.up * rotateUnit * -1f);
			//transform.Rotate (Vector3.up * rotateUnit * -1f);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			body.AddTorque (Vector3.up * rotateUnit);
			//transform.Rotate (Vector3.up * rotateUnit);
		}
	}
}
