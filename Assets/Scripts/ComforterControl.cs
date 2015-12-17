using UnityEngine;
using System.Collections;

public class ComforterControl : MonoBehaviour
{

	MeshFilter mFilter; //shortcut to meshFilter
	
	//Vector3[] originalVertices;
	Vector3[] vertsToSleep;
	Cloth clothComponent;
	bool vertsAsleep = false;

	AudioSource comforterSound;
	public float timeUntilSleep = 5.0f;

	//public GameObject stillMesh;
	public GameObject thisMesh;
	MeshFilter stillMFilter;


	// Use this for initialization
	void Start ()
	{
		mFilter = GetComponent<MeshFilter> ();
		//stillMFilter = stillMesh.GetComponent<MeshFilter> ();
		clothComponent = GetComponent<Cloth> ();

		StartCoroutine ("waitToSleep", timeUntilSleep);
		Debug.Log ("Wait for sleep called");

		//originalVertices = mFilter.mesh.vertices.Clone () as Vector3[];
		//comforterSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void LateUpdate ()
	{
		if (vertsAsleep) {
			makeVertsSleep ();
		}
	}

	IEnumerator waitToSleep (float seconds)
	{
		yield return new WaitForSeconds (seconds);
		vertsToSleep = clothComponent.vertices;
		vertsAsleep = true;
		//passClothVertsToMesh ();
		//clothComponent.enabled = false;

		//clothComponent.SetEnabledFading (false, 0.5f);
		Debug.Log ("Disabling cloth motion");
		/*
		vertsToSleep = mFilter.mesh.vertices.Clone () as Vector3[];
		GameObject stillMesh = (GameObject)Instantiate (thisMesh, thisMesh.transform.position, Quaternion.identity);
		stillMFilter = stillMesh.GetComponent<MeshFilter> ();
		makeClothCopyMesh (stillMesh);
		clothComponent = stillMesh.GetComponent<Cloth> ();
		clothComponent.coefficients
		Destroy (clothComponent);
		thisMesh.SetActive (false);
		//clothComponent.SetActive (false);
		*/
	}

	void makeVertsSleep ()
	{
		//clothComponent.vertices = vertsToSleep;
	}

	void passClothVertsToMesh ()
	{
		Mesh deformedMesh = new Mesh ();
		deformedMesh.vertices = vertsToSleep; 
		deformedMesh.triangles = mFilter.mesh.triangles;
		deformedMesh.uv = mFilter.mesh.uv;
		//deformedMesh.normals = mFilter.mesh.normals;
		deformedMesh.tangents = mFilter.mesh.tangents;
		
		deformedMesh.RecalculateNormals ();
		
		//put the mesh back into the NEW mesh filter
		mFilter.mesh = deformedMesh;
		
		//put mesh into the NEW mesh collider too!
		//newMeshObject.GetComponent<MeshCollider> ().sharedMesh = deformedMesh;
	}

	void makeClothCopyMesh (GameObject newMeshObject)
	{
		Mesh deformedMesh = new Mesh ();
		deformedMesh.vertices = vertsToSleep; 
		deformedMesh.triangles = mFilter.mesh.triangles;
		deformedMesh.uv = mFilter.mesh.uv;
		//deformedMesh.normals = mFilter.mesh.normals;
		deformedMesh.tangents = mFilter.mesh.tangents;
		
		deformedMesh.RecalculateNormals ();
		
		//put the mesh back into the NEW mesh filter
		stillMFilter.mesh = deformedMesh;
		
		//put mesh into the NEW mesh collider too!
		//newMeshObject.GetComponent<MeshCollider> ().sharedMesh = deformedMesh;
	}
}
