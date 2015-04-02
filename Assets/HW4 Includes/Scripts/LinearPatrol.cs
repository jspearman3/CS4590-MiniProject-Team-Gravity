using UnityEngine;
using System.Collections;

public class LinearPatrol : MonoBehaviour {
	public GameObject[] patrolPoints;
	public float speed;
	public float rotationSpeed;
	private CharacterController cc;
	private int destinationIndex;
	private bool routeDirection;
	private bool isMoving;
	private bool isWaiting;

	// Use this for initialization
	void Start () {
		destinationIndex = 0;
		isMoving = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving) {
			moveTo(patrolPoints[destinationIndex].transform.position);

		} else {
			moveTo (getNextPatrolPoint());
			Debug.Log("new destination: " + destinationIndex);
		}

	}

	private void moveTo(Vector3 destination) {
		Vector3 targetDir = destination - transform.position;
		Debug.Log (targetDir.magnitude);
		if (targetDir.magnitude > 0.1) {
			isMoving = true;
			float step = rotationSpeed * Time.deltaTime;
			transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.LookRotation(targetDir, transform.up), step);

			transform.Translate (speed * targetDir.normalized * Time.deltaTime, Space.World);
			Debug.Log((speed * targetDir.normalized * Time.deltaTime).magnitude);
		} else {
			isMoving = false;
		}

	}

	private Vector3 getNextPatrolPoint() {
		if (destinationIndex == 0) {
			routeDirection = true;
		} else if (destinationIndex == patrolPoints.Length - 1) {
			routeDirection = false;
		}

		if (routeDirection) {
			destinationIndex++;
		} else {
			destinationIndex--;
		}

		return patrolPoints [destinationIndex].transform.position;
	}
}
