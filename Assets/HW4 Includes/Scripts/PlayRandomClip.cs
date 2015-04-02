using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayRandomClip : MonoBehaviour
{
    public AudioClip far_clip;
    public AudioClip clip0;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    public AudioClip clip5;
    public AudioClip clip6;
    public AudioClip clip7;
    public List<AudioClip> random_clips = new List<AudioClip>();
	private Transform listener;
	private float distanceToListener = 1F;

	void Start ()
    {
        random_clips.Add( clip0 );
        random_clips.Add( clip1 );
        random_clips.Add( clip2 );
        random_clips.Add( clip3 );
        random_clips.Add( clip4 );
        random_clips.Add( clip5 );
        random_clips.Add( clip6 );
	}
	
	void Update ()
    {
        listener = AudioListenTransform.getListenerTransform();
        distanceToListener = Vector3.Distance( audio.transform.position, listener.position );
//        int distanceToListener = 3;

        AudioClip playNext;

        if( distanceToListener < 10 )
        {
            int rand = (int)Random.Range( 0F, 6F );
            playNext = random_clips[rand];

		}
        else
        {
            playNext = far_clip;
		}

		if ( !audio.isPlaying )
        {
            audio.clip = playNext;
            audio.Play();
		}
	}
}
