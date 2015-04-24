using UnityEngine;
using System.Collections;

public class ToolEscape : MonoBehaviour {

	public GameObject toolEscape;
	
	private AudioSource toolEscapeSource; 

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
		audio.Play ();
	}
}
