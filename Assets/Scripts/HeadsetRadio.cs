using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeadsetRadio : MonoBehaviour 
{
	public AudioClip clip0;
	public AudioClip clip1;
	public AudioClip clip2;
	public AudioClip clip3;
	public AudioClip clip4;
	public AudioClip clip5;

	public List<AudioClip> random_clips = new List<AudioClip>();
	private AudioSource[] audioSources;

	private float radioTimer;
	
	void Start ()
	{
		random_clips.Add( clip0 );
		random_clips.Add( clip1 );
		random_clips.Add( clip2 );
		random_clips.Add( clip3 );
		random_clips.Add( clip4 );

		radioTimer = 60F;

		audioSources = GameObject.Find("LoudAlerts").GetComponentsInChildren<AudioSource>();
	}
	
	void Update ()
	{
		radioTimer -= Time.deltaTime;

		
		AudioClip playNext;

			int rand = (int)Random.Range( 0F, 4F );
			playNext = random_clips[rand];
			
		
		if ( !audio.isPlaying && radioTimer <= 0)
		{
			audio.clip = playNext;
			audio.Play();
			radioTimer = 60F;
		}

		if (audio.isPlaying) {

			foreach (AudioSource a in audioSources) {
				a.volume = 0.2F;
			}
		} else {
			foreach (AudioSource a in audioSources) {

				a.volume = 0.5F;
			}
		}

	}
}
