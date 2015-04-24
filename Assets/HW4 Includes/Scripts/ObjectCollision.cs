using UnityEngine;
using System.Collections;

public class ObjectCollision : MonoBehaviour {
	public AudioClip fastBump;
	public AudioClip slowBump;
	public AudioSource collisionPlayer;
	
	void OnCollisionEnter(Collision collision) {
		Rigidbody body = GetComponent<Rigidbody>();
		Rigidbody wall = collision.collider.attachedRigidbody;
		if (wall == null || wall.isKinematic) {
			//Debug.Log("Collision detected");
			if (body.velocity.magnitude > 6) {
				collisionPlayer.volume = 1;
			} else {
				collisionPlayer.volume = body.velocity.magnitude / 6;
			}
			
			if (body.velocity.magnitude > 3) {
				collisionPlayer.clip = fastBump;
				collisionPlayer.Play();
			} else {
				collisionPlayer.clip = slowBump;
				collisionPlayer.Play();
			}
		
		}
	}
}
