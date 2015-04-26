using UnityEngine;
using System.Collections;

public class ProximityAlert : MonoBehaviour
{
    public AudioSource alert;
    public Collider person;
    bool too_far_away;
	bool alertEnabled;
	// Use this for initialization
	void Start()
    {
        too_far_away = false;
	}
	
	// Update is called once per frame
	void Update()
    {
        if( too_far_away && !alert.isPlaying )
        {
            alert.Play();
			Debug.Log ("too far & play");

        }
	}

    void OnTriggerExit( Collider person )
    {
		if (alertEnabled) {
			too_far_away = true;
			Debug.Log ("exited & enabled");
		}
		Debug.Log ("exited");
    }

    void OnTriggerEnter( Collider person )
    {

		too_far_away = false;
		Debug.Log ("entered");
		        
    }

	public void toggle() {
		alertEnabled = !alertEnabled;
		too_far_away = false;
		Debug.Log ("toggled");
	}

	public bool getTooFarAway() {
		return too_far_away;
	}
}
