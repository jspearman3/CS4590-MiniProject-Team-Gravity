using UnityEngine;
using System.Collections;

public class InitialKick : MonoBehaviour {
	GameObject[] floatingObjects;
	public float forceMag;

	// Use this for initialization
	void Start () {
		floatingObjects = GameObject.FindGameObjectsWithTag ("Floating Objects");

		foreach (GameObject obj in floatingObjects) {
			Vector3 randForce = Random.insideUnitSphere * forceMag;
			obj.GetComponent<Rigidbody>().AddForce(randForce, ForceMode.Impulse);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
