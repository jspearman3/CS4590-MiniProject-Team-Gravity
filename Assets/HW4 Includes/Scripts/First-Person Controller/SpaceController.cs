using UnityEngine;
using System.Collections;

public class SpaceController : MonoBehaviour {
	public float MoveSpeed;
	private Vector3 velocity;
	private CharacterController cc;
	public float breakingFactor;



	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController>();
		velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 forwardAcc = Input.GetAxis ("Vertical") * transform.TransformDirection (Vector3.forward) * MoveSpeed;
		Vector3 horizontalAcc = Input.GetAxis ("Horizontal") * transform.TransformDirection (Vector3.right) * MoveSpeed;
		Vector3 verticalAcc = Input.GetAxis ("VerticalMove") * transform.TransformDirection (Vector3.up) * MoveSpeed;

		Vector3 acceleration = (forwardAcc + horizontalAcc + verticalAcc);

		velocity += (acceleration * Time.deltaTime);

		cc.Move(velocity * Time.deltaTime);

		float spinSensitivity = 50f;
		float spin = Input.GetAxis ("Spin") * spinSensitivity;
		transform.Rotate (new Vector3 (0, 0, spin) * Time.deltaTime);
	}

	void OnTriggerStay (Collider other) {
		if (Input.GetKey("f")) {
			Debug.Log ("F is held and the collider hit " + other.name);
			if (velocity.magnitude > 0) {
				velocity = velocity * breakingFactor;
			}

		}
	}
	


}