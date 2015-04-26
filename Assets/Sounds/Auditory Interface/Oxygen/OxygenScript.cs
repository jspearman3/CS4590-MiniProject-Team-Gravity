using UnityEngine;
using System.Collections;

public class OxygenScript : MonoBehaviour {

	public float percentOxygenLeft; //if it's static, I can't alter it within Unity,
				//BUT, when we have a master class to take care of hotkeys, it can access it if it's static
				//I THINK.

	public AudioClip fiftyPercent;
	public AudioClip twentyFivePercent;
	public AudioClip tenPercent;

	bool playing50;
	bool playing25;

	// Use this for initialization
	void Start () {

		playing50 = false;
		playing25 = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		//now let's deal with different oxygen levels

		//if it's above 50%, we don't want anything playing
		if (percentOxygenLeft > 50f) {

				audio.Stop ();

		} else if (percentOxygenLeft == 50f) {

				//play the 50% warning
				audio.clip = fiftyPercent;
				audio.loop = false;
			if (!audio.isPlaying && !playing50) {
				audio.Play ();
				playing50 = true;
				playing25 = false;
			}
		} else if (percentOxygenLeft == 25f) {

				//play the 25% warning
				audio.clip = twentyFivePercent;
				audio.loop = false;
			if (!audio.isPlaying && !playing25) {
				audio.Play ();
				playing25 = true;
				playing50 = false;
			}
		} else if (percentOxygenLeft <= 10f) {

				//play the continuous <=10% warning
				audio.clip = tenPercent;
				audio.loop = true;
			if (!audio.isPlaying) {
				audio.Play ();
				playing25 = false;
				playing50 = false;
			}
		} else {

			//in all other cases, we want silence
			if (audio.isPlaying) {

				audio.Stop();
				playing25 = false;
				playing50 = false;
			}

		}

	
	}
}
