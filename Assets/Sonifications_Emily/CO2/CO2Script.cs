using UnityEngine;
using System.Collections;

public class CO2Script : MonoBehaviour {

	public float co2Percent;

	public AudioClip point5Percent;
	public AudioClip onePercent;

	bool playingPoint5;
	bool playing1;

	// Use this for initialization
	void Start () {

		playingPoint5 = false;
		playing1 = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		//deal with varying CO2 levels.

		//at 0.5%, want to play basic warning
		if (co2Percent == 0.5f) {

				audio.clip = point5Percent;
				audio.loop = false;
				audio.pitch = 1f;
				if (!audio.isPlaying && !playingPoint5) {
						audio.Play ();
						playingPoint5 = true;
						playing1 = false;
				}
		} else if ((co2Percent >= 1f) && (co2Percent < 3f)) {

				//now we want to play the continuous warning
				audio.clip = onePercent;
				audio.loop = true;
				audio.pitch = 1f;
				if (!audio.isPlaying && !playing1) {
						audio.Play ();
						playing1 = true;
						playingPoint5 = false;
				}
		} else if (co2Percent >= 3f) {

				//if it's made it to 3%, we want to up the pitch.
				audio.clip = onePercent;
				audio.pitch = 2f;
				audio.loop = true;
				if (!audio.isPlaying && !playing1) {
						audio.Play ();
						playing1 = true;
						playingPoint5 = false;
				}

		} else {

				//in all other cases, we want silence
				if (audio.isPlaying) {
		
						audio.Stop ();
						playingPoint5 = false;
						playing1 = false;
				}
		}

	}
}
