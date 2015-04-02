using UnityEngine;
using System.Collections;

public class BootUp : MonoBehaviour {

	public int startingPitch = 1;
	public bool increase = true;
	public float currentTime;
	public float tol = 0.00001f;

	// Use this for initialization
	void Start () {

		audio.pitch = 1f;
	
	}
	
	public void Update() {

		currentTime = Time.time;

		//Debug.Log ("Current time: " + currentTime);

		//increase at 1
		if (Mathf.Abs(audio.pitch - 1) < tol) {

				increase = true;

		//decrease from 3
		} else if (Mathf.Abs(audio.pitch - 3) < tol) {

				increase = false;

		}

		//only change every 2 seconds
		if (currentTime %6 < 0.5) {


				if (increase) {

						audio.pitch += 0.01f;

				} else {

						audio.pitch -= 0.01f;
				}

		}


	}


}
