using UnityEngine;
using System.Collections;

public class AlertxTimes : MonoBehaviour
{

    public string keypress;
    public int num_times;
	
	public void playAlert ()
    {
        if (!audio.isPlaying )
        {
			StartCoroutine( PlayTimes (num_times) );          
        }
	}

    IEnumerator PlayTimes( int times )
    {
        for( int i=0; i<times; i++ )
        {
            audio.Play();
            yield return new WaitForSeconds(audio.clip.length);
        }
    }
}
