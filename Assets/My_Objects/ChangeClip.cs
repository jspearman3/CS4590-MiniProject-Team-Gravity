using UnityEngine;
using System.Collections;

public class ChangeClip : MonoBehaviour {

	public AudioClip Far_Clip;
	public AudioClip Close_Clip;

	Transform listener; 
	float distanceToListener = 1f;

	// Use this for initialization
	void Start () {
	
		audio.clip = Far_Clip;
		audio.Play ();

	}
	
	// Update is called once per frame
	void Update () {

		listener = AudioListenTransform.getListenerTransform ();
		Debug.Log (audio.isPlaying);
	
		distanceToListener = Vector3.Distance(audio.transform.position, listener.position);
		//distanceToListener = (audio.transform.position - listener.position).magnitude;

		if (distanceToListener < 5) {

				audio.clip = Close_Clip;
				//audio.Play ();
		} else {

				audio.clip = Far_Clip;
		}
		if (!audio.isPlaying) {

				audio.Play ();
		}

	}
}
