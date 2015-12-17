using UnityEngine;
using System.Collections;

public class TrashDeform : MonoBehaviour
{

	public float distortionMax = 0.1f;
	public GameObject trashContents;
	//the MeshFilter tells unity what mesh we're using
	MeshFilter mFilter; //shortcut to meshFilter
	Vector3[] originalVertices;

	// Use this for initialization
	void Start ()
	{
		mFilter = trashContents.GetComponent<MeshFilter> ();
		originalVertices = mFilter.mesh.vertices.Clone () as Vector3[];
		deform ();

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void reset (int day)
	{
		switch (day) {
		default:
			deform ();
			break;
		}
	}

	void deform ()
	{
		Vector3[] newVertices = originalVertices.Clone () as Vector3[];
		
		for (int i=0; i<newVertices.Length; i++) {

			float xDeform = Random.Range (distortionMax * -1f, distortionMax);
			float yDeform = Random.Range (distortionMax * -1f, distortionMax);
			float zDeform = Random.Range (distortionMax * -1f, distortionMax);
			//float noise = Mathf.PerlinNoise (newVertices [i].x * (Time.time + i) * oceanSpeed, newVertices [i].z * (Time.time + i) * oceanSpeed);
			//Debug.Log ("Noise at " + i + ": " + noise);
			//newVertices [i] += new Vector3 (0f, noise * oceanHeight, 0f);
			newVertices [i] += new Vector3 (xDeform, yDeform * 2f, zDeform);
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
		//GetComponent<MeshCollider> ().sharedMesh = deformedMesh;
	}
}
