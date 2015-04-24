using UnityEngine;
using System.Collections;

public class ToolManager : MonoBehaviour {

	public GameObject[] tools;
	public AudioClip[] toolSounds;
	public GameObject hand;

	private int currentToolIndex;
	private GameObject currentTool;
	private AudioSource handSource;

	private float drillTimer;
	private float drillVolume;

	private float hammerTimer;

	private float wrenchTimer;
	private float wrenchVolume;

	private float boltPullerVolume;
	private bool boltPullerEnabled;

	private float TGATimer;
	private float TGAVolume;



	// Use this for initialization
	void Start () {
		currentToolIndex = -1;
		currentTool = null;

		drillTimer = 0;
		drillVolume = 0.2F;

		hammerTimer = 0;

		wrenchTimer = 0;
		wrenchVolume = 0.6F;

		boltPullerVolume = 0.2F;
		boltPullerEnabled = true;

		TGATimer = 0;
		TGAVolume = 0.5F;

		handSource = hand.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!(currentToolIndex == -1) && Input.GetButton ("Fire1")) {
			playToolSound ();
		} else if (!(currentToolIndex == -1) && Input.GetKeyDown ("c") && !handSource.isPlaying) {
			currentToolIndex++;

			if (currentToolIndex == tools.Length) {
				currentToolIndex = 0;
			}

			switchTool (currentToolIndex);

		} else if (!(currentToolIndex == -1) && Input.GetKeyDown ("x") && !handSource.isPlaying) {
			currentToolIndex--;
			
			if (currentToolIndex == -1) {
				currentToolIndex = tools.Length - 1;
			}

			switchTool (currentToolIndex);

		} else {
			cooldown();
		}
	
	}

	public void toggleTools() {
		if (currentToolIndex == -1) {
			currentToolIndex = 0;
			currentTool = (GameObject) Instantiate(tools[0], hand.transform.position, hand.transform.rotation);
			currentTool.transform.SetParent (hand.transform);
		} else {
			currentToolIndex = -1;
			Destroy(currentTool);
		}
	}

	private void switchTool(int index) {
		Destroy (currentTool);
		currentTool = (GameObject) Instantiate(tools[index], hand.transform.position, hand.transform.rotation);
		currentTool.transform.SetParent (hand.transform);
	}

	public void playToolSound() {
		if (currentToolIndex == 0) {
			drillTimer += 2 * Time.deltaTime;

			if (drillTimer > 1) {
				drillTimer = 1;
			} 

			handSource.loop = true;
			handSource.pitch = drillTimer;
			handSource.volume = drillVolume;

			if (!handSource.isPlaying) {
				handSource.clip = toolSounds[0];
				handSource.Play();
			}
		


		} else if (currentToolIndex == 1) {
			handSource.loop = false;
			handSource.clip = toolSounds[1];

			hammerTimer += Time.deltaTime;

			if (hammerTimer >= 1) {
				hammerTimer = 1;
			}

		} else if (currentToolIndex == 2) {
			handSource.loop = false;
			handSource.clip = toolSounds[2];
			handSource.volume = wrenchVolume;
			
			wrenchTimer -= Time.deltaTime;
			
			if (wrenchTimer <= 0) {
				handSource.Play ();
				wrenchTimer = 1;
			}


		} else if (currentToolIndex == 3) {
			if (boltPullerEnabled) {
				handSource.loop = false;
				handSource.clip = toolSounds[3];
				handSource.volume = boltPullerVolume;
				handSource.Play ();
				boltPullerEnabled = false;

			}
		} else if (currentToolIndex == 4) {
			TGATimer += 2 * Time.deltaTime;

			if (TGATimer >= 1) {
				TGATimer = 1;
			}
			currentTool.GetComponent<AudioSource>().volume = TGAVolume;
			currentTool.GetComponent<AudioSource>().pitch = TGATimer * 6 + 1;
		}
	}

	private void cooldown() {
		if (currentToolIndex == 0) {
			drillTimer -= 2 * Time.deltaTime;
			handSource.pitch = drillTimer;

			if (drillTimer <= 0) {
				drillTimer = 0;
				handSource.Stop ();
				handSource.pitch = 1;
			}

		} else if (currentToolIndex == 1) {
			if (hammerTimer > 0) {
				handSource.volume = hammerTimer;
				handSource.Play ();
				hammerTimer = 0;
			}
		} else if (currentToolIndex == 2) {
			wrenchTimer -= Time.deltaTime;

			if (wrenchTimer <= 0) {
				wrenchTimer = 0;
			}
		} else if (currentToolIndex == 3) {
			boltPullerEnabled = true;

		} else if (currentToolIndex == 4) {
			TGATimer -= 2 * Time.deltaTime;

			
			if (TGATimer <= 0) {
				TGATimer = 0;
			}

			currentTool.GetComponent<AudioSource>().volume = TGAVolume;
			currentTool.GetComponent<AudioSource>().pitch = TGATimer * 6 + 1;
		}
	}
}
