using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Checklist : MonoBehaviour
{	
	public GameObject checklist;

	public GameObject curtainsX;
	public GameObject bedX;
	public GameObject deskX;
	public GameObject phoneX;
	public GameObject trashX;
	public GameObject toiletX;
	public GameObject sinkX;

	float UITextFadeTimer = 10;

	//function must be public void in order for UI to call it
	public void OpenCheckList ()
	{
		if (!checklist.activeSelf) {
			checklist.SetActive (true);
		} else {
			checklist.SetActive (false);
		}

		/*
		if (!gameObject.activeSelf) {
			gameObject.SetActive (true);
		} else {
			gameObject.SetActive (false);
		}*/
	}
//
	//public void TargetClicked (GameObject target)
	//{
	//if (target == "whatever") {
	//GameObject clickedTarget = target;
	//clickedTarget = target + "X";
	//clickedTarget.SetActive (true);
	//}

	//}
}
