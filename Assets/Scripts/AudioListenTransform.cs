using UnityEngine;
using System.Collections;

public class AudioListenTransform : MonoBehaviour {

	public static Transform listenerTransform;
	AudioListener listener;

	// Use this for initialization
	void Start () {

		listener = GetComponent<AudioListener> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		listenerTransform = listener.transform;
	}

	public static Transform getListenerTransform () {

			return listenerTransform;

	}
}
