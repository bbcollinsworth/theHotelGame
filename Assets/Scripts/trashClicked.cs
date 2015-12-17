using UnityEngine;
using System.Collections;

public class trashClicked : MonoBehaviour
{

	public GameObject trashX;
	public GameObject contents;

	AudioSource emptyTrash;

	bool isEmpty;

	// Use this for initialization
	void Start ()
	{
		emptyTrash = GetComponent<AudioSource> ();
		isEmpty = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void onClick ()
	{
		if (!isEmpty) {
			//if (!emptyTrash.isPlaying) {
			emptyTrash.Play ();
			//}
			contents.SetActive (false);
			trashX.SetActive (true);
			isEmpty = true;
		}
	}

	void reset (int day)
	{
		contents.SetActive (true);
		trashX.SetActive (false);
		isEmpty = false;
	}
}
