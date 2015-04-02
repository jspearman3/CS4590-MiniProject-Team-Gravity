using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayGreeting : MonoBehaviour
{
    public AudioSource constant;
    public AudioSource greeting;
    public AudioClip clip0;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    public AudioClip clip5;
    public AudioClip clip6;
    public AudioClip clip7;
    public List<AudioClip> random_clips = new List<AudioClip>();
    bool exitArea = true;
	private Transform listener;
	float distanceToListener = 1f;

	// Use this for initialization
	void Start()
    {
        random_clips.Add( clip0 );
        random_clips.Add( clip1 );
        random_clips.Add( clip2 );
        random_clips.Add( clip3 );
        random_clips.Add( clip4 );
        random_clips.Add( clip5 );
        random_clips.Add( clip6 );
	}
	
	// Update is called once per frame
	void Update()
    {
        listener = AudioListenTransform.getListenerTransform();
        distanceToListener = Vector3.Distance( audio.transform.position, listener.position );
     //   int distanceToListener = 3;

        bool playGreet = false;

        if( distanceToListener < 5 && exitArea == true )
        {
            playGreet = true;
		}
        else if ( distanceToListener >=5 )
        {
            exitArea = true;
        }

		if ( playGreet && !greeting.isPlaying )
        {
            exitArea = false;

            int rand = (int)Random.Range( 0F, 6F );
            greeting.clip = random_clips[rand];

            constant.Pause();
            greeting.Play();
            StartCoroutine( Wait( 3 ) );
            constant.Play();
		}
	}

    public IEnumerator Wait( float seconds )
    {
        yield return new WaitForSeconds( seconds );
    }
}
