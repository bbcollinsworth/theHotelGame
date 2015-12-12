using UnityEngine;
using System.Collections;

public class deskDust : MonoBehaviour
{

	Renderer rend;

	bool dust = false;

	public GameObject deskX;
	public Transform shaderedDesk;

	float shininess;

	// Use this for initialization
	void Start ()
	{
		//rend = shaderedDesk.GetComponent<Renderer> ();
		
		//rend.material.shader = Shader.Find ("Specular");
	}
	
	// Update is called once per frame

	

	void onClick ()
	{
		
		dust = true;
		

		

		
	}

	void reset (int day)
	{
		shininess = 0f;
		//rend.material.SetFloat ("_Shininess", shininess);
		deskX.SetActive (false);
	}
	
	
	void Update ()
	{
		
		if (dust) {
			
			if (shininess <= 0.8f) {
				
				shininess += 0.04f;
				
				//rend.material.SetFloat ("_Shininess", shininess);
				
			} else {
				
				//rend.material.SetFloat ("Shininess", 0.8f);

				deskX.SetActive (true);
				dust = false;
				
			}
			
		}
		
	}
}
