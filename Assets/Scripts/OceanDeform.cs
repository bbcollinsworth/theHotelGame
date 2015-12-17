using UnityEngine;
using System.Collections;

public class OceanDeform : MonoBehaviour
{
	public float rippleHeight = 1f;
	public float rippleTightness = 1f;
	public float maxScaleX;
	public float minScaleX;

	public GameObject curtainsX;

	public Transform curtainPivot;

	AudioSource curtainSound;
	//the MeshFilter tells unity what mesh we're using
	MeshFilter mFilter; //shortcut to meshFilter
	Vector3[] originalVertices;

	float curtainScale;
	bool moveCurtain;
	public bool isOpen = false;

	// Use this for initialization
	void Start ()
	{
		mFilter = GetComponent<MeshFilter> ();
		originalVertices = mFilter.mesh.vertices.Clone () as Vector3[];
		curtainSound = GetComponent<AudioSource> ();

		rippleCurtain ();
		//curtainScale = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//if (Input.GetKeyDown (KeyCode.X)) {
		//moveCurtain = true;
		//scaleCurtain (0.5f);
		//}
		if (isOpen) {
			curtainsX.SetActive (true);
		} else {
			curtainsX.SetActive (false);
		}

		if (moveCurtain) {
			scaleCurtain ();
		}

		if (curtainPivot.localScale.x != curtainScale) {
			rippleCurtain ();
		}
	}

	void onClick ()
	{
		moveCurtain = true;
		curtainSound.Play ();
	}

	void reset (int day)
	{
		switch (day) {
		case 2:
			if (!isOpen) {
				moveCurtain = true;
			}
			break;
		case 1:
		default:
			if (isOpen) {
				moveCurtain = true;
			}
			break;
		}


	}

	void rippleCurtain ()
	{
		float heightMod = rippleHeight * 1f / curtainPivot.localScale.x; //to make ripples larger when curtain is tight
		
		Vector3[] newVertices = originalVertices.Clone () as Vector3[];
		
		for (int i=0; i<newVertices.Length; i++) {
			//float noise = Mathf.PerlinNoise (newVertices [i].x * (Time.time + i) * oceanSpeed, newVertices [i].z * (Time.time + i) * oceanSpeed);
			//Debug.Log ("Noise at " + i + ": " + noise);
			//newVertices [i] += new Vector3 (0f, noise * oceanHeight, 0f);
			newVertices [i] += new Vector3 (0f, Mathf.Sin (newVertices [i].x * rippleTightness) * heightMod, 0f);
		}
		
		Mesh deformedMesh = new Mesh ();
		deformedMesh.vertices = newVertices; 
		deformedMesh.triangles = mFilter.mesh.triangles;
		deformedMesh.uv = mFilter.mesh.uv;
		//deformedMesh.normals = mFilter.mesh.normals;
		deformedMesh.tangents = mFilter.mesh.tangents;
		
		deformedMesh.RecalculateNormals ();
		
		//put the mesh back into the mesh filter
		mFilter.mesh = deformedMesh;
		
		//put mesh into the mesh collider too!
		GetComponent<MeshCollider> ().sharedMesh = deformedMesh;

		curtainScale = curtainPivot.localScale.x;
	}

	void scaleCurtain ()
	{
		//float targetScale;
		//curtainSound.Play ();

		if (isOpen) {
			float targetScale = maxScaleX;
			moveCurtainToTarget (targetScale);
		} else {
			float targetScale = minScaleX;
			moveCurtainToTarget (targetScale);

		}

	}

	void moveCurtainToTarget (float targetX)
	{
		Vector3 target = new Vector3 (targetX, curtainPivot.localScale.y, curtainPivot.localScale.z);
		if (Mathf.Abs (targetX - curtainPivot.localScale.x) > 0.001) {
			curtainPivot.localScale = Vector3.Lerp (curtainPivot.localScale, target, 0.1f);
		} else {
			curtainPivot.localScale = target;
			isOpen = !isOpen;
			moveCurtain = false;
		}


	}

	//IEnumerator scaleCurtain
}
