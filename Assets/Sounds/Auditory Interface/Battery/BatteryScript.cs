using UnityEngine;
using System.Collections;

public class BatteryScript : MonoBehaviour {

	public float batteryPercentLeft;

	public AudioClip twentyPercent;
	public AudioClip tenPercent;

	bool playing20;
	bool playing10;

	// Use this for initialization
	void Start () {
	
		playing10 = false;
		playing20 = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (batteryPercentLeft == 20f) {

				//play the 20% warning
				audio.clip = twentyPercent;
				audio.loop = false;
				if (!audio.isPlaying && !playing20) {
						audio.Play ();
						playing20 = true;
						playing10 = false;
				}
		} else if (batteryPercentLeft == 10f) {

				//10% warning
				audio.clip = tenPercent;
				audio.loop = false;
				if (!audio.isPlaying && !playing10) {
						audio.Play ();
						playing10 = true;
						playing20 = false;
				}

			//do we want it to go continuous around 5%? I think too many continuous alarms
			//is just irritating.
		} else {

			//in all other cases, we want silence
			if (audio.isPlaying) {
				
				audio.Stop();
				playing20 = false;
				playing10 = false;
			}
			
		}
	
	}
}
