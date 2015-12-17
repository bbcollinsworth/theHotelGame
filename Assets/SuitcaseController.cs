using UnityEngine;
using System.Collections;

public class SuitcaseController : MonoBehaviour
{

	public GameObject lid;
	Rigidbody lidBody;
	public float openForce;

	bool lidClosed = false;
	bool lidMoving = false;

	// Use this for initialization
	void Start ()
	{
		lidBody = lid.GetComponent<Rigidbody> ();
		lidClosed = lidClosedCheck ();
		Debug.LogWarning ("LidClosed is " + lidClosed);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void onClick ()
	{
		if (!lidMoving) {
			if (lidClosed) {

			}
		}
	}

	void reset (int day)
	{
		float randomRot = Random.Range (10f, 20f);

		transform.Rotate (Vector3.up * randomRot);
	}

	bool lidClosedCheck ()
	{
		float r = lidRotation ();
		if (r > 179 && r < 200) {
			return true;
		} else {
			return false;
		}
	}

	IEnumerator moveLid (string dir)
	{
		lidMoving = true;
		switch (dir) {
		case "close":
			while (lidRotation ()<180 || lidRotation()>200) {
				lidBody.AddRelativeTorque (Vector3.forward * openForce);
				yield return 0;
			}
			lidClosed = true;
			break;
		case "open":
			while (lidRotation ()>180 || lidRotation()<200) {
				lidBody.AddRelativeTorque (Vector3.forward * openForce * -1f);
				yield return 0;
			}
			lidClosed = false;
			break;
		
		}
		lidMoving = false;

	}

	float lidRotation ()
	{
		return lid.transform.localRotation.eulerAngles.z;
	}
}
