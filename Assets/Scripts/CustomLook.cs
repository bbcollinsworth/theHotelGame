using UnityEngine;
using System.Collections;

public class CustomLook : MonoBehaviour
{
	//public Camera mainCam;
	public Transform mainCam;

	public float moveZoneMin = 0.3f;
	public float maxRot = 50f;
	public float sensitivity = 0.1f;

	float centeredMouseY, centeredMouseX = 0f;
	bool looking = false;


	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		centeredMouseY = (Input.mousePosition.y / Screen.height - 0.5f) * 2f;
		centeredMouseX = (Input.mousePosition.x / Screen.width - 0.5f) * 2f;

		//Debug.LogWarning ("Centered MouseY: " + centeredMouseY);

		if (Mathf.Abs (centeredMouseY) > moveZoneMin) {
			looking = true;
			/*verticalRotate ();*/
		} else {
			//mainCam.localRotation = Quaternion.Euler (0f, 0f, 0f);
			looking = false;
		}

		verticalRotate ();


	}

	public void verticalRotate ()
	{
		float rotationV = 0;

		if (looking) {
			rotationV = map (Mathf.Abs (centeredMouseY), moveZoneMin, 1f, 0, maxRot);


			if (centeredMouseY > 0) {
				rotationV *= -1f;
			}
		}

		//Debug.LogWarning ("Rot degrees: " + rotationV);

		/*float normalizedRot = abs(Input.mousePosition.y - zoneEdge)*maxRot;*/

		float currentRotV = mainCam.localRotation.eulerAngles.x;

		/*Debug.LogWarning ("Current Rot V: " + currentRotV);*/
		if (currentRotV >= 180f) {
			currentRotV = (currentRotV - 360f);// * -1f;
		}
		//Debug.LogWarning ("Current Rot V: " + currentRotV);

		if (Mathf.Abs (currentRotV - rotationV) > 0.1f) {
			Vector3 target = new Vector3 (rotationV, 0f, 0f);
			Vector3 current = new Vector3 (currentRotV, 0f, 0f);
			Vector3 lerpedVector = Vector3.Lerp (current, target, sensitivity);
			mainCam.localRotation = Quaternion.Euler (lerpedVector);
			/*mainCam.localRotation = Quaternion.Euler (rotationV, 0f, 0f);*/
		}
	}

	float map (float varToMap, float varMin, float varMax, float mapToMin, float mapToMax)
	{
		var mappedValue = mapToMin + (mapToMax - mapToMin) * ((varToMap - varMin) / (varMax - varMin));
		return mappedValue;
	}
}
