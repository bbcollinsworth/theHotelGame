using UnityEngine;
using System.Collections;

public class chairControl : MonoBehaviour
{

	//Rigidbody chairBody;
	public Transform player;
	//public Transform chairContainer;
	public Rigidbody chairBody;
	public float pushForce = 100;

	Vector3 startPos;
	Quaternion startRot;

	// Use this for initialization
	void Start ()
	{
		//chairBody = GetComponent<Rigidbody> ();

		startPos = transform.position;
		Debug.LogWarning ("Chair Pos: " + startPos);
		startRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void onClick ()
	{
		Debug.LogWarning ("Chair Collider Clicked!");
		Vector3 playerToChair = transform.position - player.position;
		playerToChair.Normalize ();
		Debug.LogWarning ("Chair Push Vector is: " + playerToChair);
		chairBody.AddForce (playerToChair * pushForce);
	}

	void reset (int day)
	{

		//switch (day) {
		//default:
		transform.position = startPos;
		Debug.LogWarning ("Chair Pos reset to: " + startPos.x + ", " + startPos.y + ", " + startPos.z);
		Debug.LogWarning ("Chair pos is actually: " + transform.position);
		transform.rotation = startRot;
		Debug.LogWarning ("Chair Reset Received!");
		//break;
		//}
	}
}
