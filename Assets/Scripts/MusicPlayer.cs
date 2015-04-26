using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	public AudioClip[] songs;
	public AudioSource musicPlayer;
	public int songIndex;

	// Use this for initialization
	void Start () {
		songIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!audio.isPlaying) {
			musicPlayer.clip = songs[songIndex];
			musicPlayer.Play();
			incSongIndex();
		}
	}

	private void incSongIndex(){
		if (songIndex >= songs.Length) {
			songIndex = 0;
		} else {
			songIndex++;
		}
	}
}
	