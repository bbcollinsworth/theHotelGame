using UnityEngine;
using System.Collections;

public class clickAction : MonoBehaviour
{

	//public Transform sphere;
	public Camera cam;

	public string functionToCallOnClick = "onClick";

	public float clickRange = 20f;

	public LayerMask clickableLayer;

	Vector3 startPos;
	Quaternion startRot;

	Vector3 prevMouse;

	//int clickableLayer = 1 << 9;
	void Start ()
	{
		startPos = cam.transform.position;
		startRot = cam.transform.rotation;

		prevMouse = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//always raycasting from mouse so we can use it to highlight objects
		Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		//generate ray based on camera view
		//		Ray lookRay = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		
		RaycastHit hit = new RaycastHit ();
		
		if (Physics.Raycast (mouseRay, out hit, clickRange, clickableLayer)) { //, clickableLayer

			Debug.Log ("Raycast Hit detected!");
			//softFocus (hit.transform);

			if (Input.GetMouseButtonDown (0)) {
				//generate ray based on mouse pos

				//			sphere.position = Vector3.Lerp (sphere.position, mouseRayHit.point - new Vector3 (0f, 0f, 0.5f), 0.1f);
				//sphere.position = mouseRayHit.point - new Vector3(0f, 0f, 0f);

				hit.transform.SendMessage (functionToCallOnClick, SendMessageOptions.DontRequireReceiver);
			}
			
		} else if (Input.mousePosition != prevMouse) {
			//Debug.LogWarning ("Reset transform called");
			//cam.transform.position = startPos;
			//cam.transform.rotation = startRot;
			//resetFocus ();
		}

		prevMouse = Input.mousePosition;
	}

	public void softFocus (Transform hitObject)
	{
		cam.transform.LookAt (hitObject);
	}

	public void resetFocus ()
	{
		if (cam.transform.position != startPos) {
			cam.transform.position = Vector3.Lerp (cam.transform.position, startPos, 0.2f);
		}

		if (cam.transform.rotation != startRot) {
			cam.transform.rotation = Quaternion.Euler (Vector3.Lerp (cam.transform.rotation.eulerAngles, startRot.eulerAngles, 0.2f));
		}
	}
}
