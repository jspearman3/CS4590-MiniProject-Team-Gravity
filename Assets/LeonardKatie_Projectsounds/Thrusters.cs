using UnityEngine;
using System.Collections;

public class Thrusters : MonoBehaviour {

	public GameObject thrusters;

	private AudioSource thrustSource;

	private float thrustTimer;
	private float thrustVolume;

	
	
	// Use this for initialization
	void Start () {
	
		thrustTimer = 0;
		thrustVolume = 0.2F;

		
		thrustSource = thrusters.GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("left shift") || Input.GetKey("space")) {
			if (GameObject.Find ("StationBorder").GetComponent<ProximityAlert>().getTooFarAway()) {
				playThrustSound();
			}
			
		} else {
			down();
		}
	
	
	}

	public void playThrustSound() {

			thrustTimer += Time.deltaTime;
			
			if (thrustTimer > 1) {
				thrustTimer = 1;
			} 
			
			thrustSource.loop = true;
			thrustSource.pitch = thrustTimer / 2;
			thrustSource.volume = thrustVolume;
			
			if (!thrustSource.isPlaying) {
				thrustSource.Play();
			}
		}

	private void down() {
			thrustTimer -= Time.deltaTime;
			thrustSource.pitch = thrustTimer;

			if (thrustTimer <= 0) {
				thrustTimer = 0;
				thrustSource.Stop ();
				thrustSource.pitch = 1;
			}
}
}
