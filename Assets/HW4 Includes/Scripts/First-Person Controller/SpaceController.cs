using UnityEngine;
using System.Collections;

public class SpaceController : MonoBehaviour {
	public float MoveSpeed;
	private Vector3 velocity;
	private CharacterController cc;
	public float breakingFactor;
	private Transform playerTransform;



	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController>();
		velocity = Vector3.zero;
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
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

		} else if (Input.GetKey("g") && other.tag == "Airlock Teleport") {
			velocity = Vector3.zero;
			playerTransform.position = new Vector3(0.3F, 5.6F, 104.9F);
			playerTransform.localEulerAngles = new Vector3(276.1F, 38.4F, 349.3F);
		} else if (Input.GetKey("g") && other.tag == "ISS Teleport") {
			velocity = Vector3.zero;
			playerTransform.position = new Vector3(9949.9F, -5.4F, 1.8F);
			playerTransform.localEulerAngles = new Vector3(4.2F, 178.0F, -1.3F);
		}
	}
	


}