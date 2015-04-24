using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Presets : MonoBehaviour {
	private Color[] colors1;
	private Color[] colors2;

	private int oxygenIndex;
	private float[] oxygenPercents;

	private int CO2Index;
	private float[] CO2Percents;

	private bool pIsBad;

	private bool lowFuel;

	private int batteryIndex;
	private float[] batteryPercents;




	// Use this for initialization
	void Start () {
		colors1 = new Color[] {Color.green, Color.green, Color.yellow, Color.red};
		colors2 = new Color[] {Color.green, Color.yellow, Color.red, Color.red};

		oxygenIndex = -1;
		oxygenPercents = new float[] {100F, 50F, 25F, 10F};

		CO2Index = -1;
		CO2Percents = new float[] {0F, 0.5F, 1F, 3F};

		pIsBad = true;

		lowFuel = true;

		batteryIndex = -1;
		batteryPercents = new float[] {100F, 20F, 10F};

		changeOxygen ();
		changeCO2 ();
		changePressure ();
		changeFuel ();
		changeBattery ();


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1")) {
			changeOxygen();
		}

		if (Input.GetKeyDown ("2")) {
			changeCO2();
		}

		if (Input.GetKeyDown ("3")) {
			changePressure();
		}

		if (Input.GetKeyDown ("4")) {
			changeFuel();
		}

		if (Input.GetKeyDown ("5")) {
			changeBattery();
		}

		if (Input.GetKeyDown ("6")) {
			coolantAlarm();
		}

		if (Input.GetKeyDown ("7")) {
			lostToolAlarm();
		}
	}

	public void changeOxygen() {
		oxygenIndex++;

		if (oxygenIndex == oxygenPercents.Length) {
			oxygenIndex = 0;
		}

		GameObject.Find ("O2%").GetComponent<Text> ().text = (oxygenPercents [oxygenIndex].ToString() + "%");
		GameObject.Find ("O2%").GetComponent<Text> ().color = colors1 [oxygenIndex];

		GameObject.Find ("OxygenAlert").GetComponent<OxygenScript> ().percentOxygenLeft = oxygenPercents [oxygenIndex];

		GameObject.Find ("WarningText").GetComponent<Text> ().text = "";
	}

	public void changeCO2() {
		CO2Index++;
		
		if (CO2Index == CO2Percents.Length) {
			CO2Index = 0;
		}
		
		GameObject.Find ("CO2%").GetComponent<Text> ().text = (CO2Percents [CO2Index].ToString() + "%");
		GameObject.Find ("CO2%").GetComponent<Text> ().color = colors2 [CO2Index];
		
		GameObject.Find ("CO2Alert").GetComponent<CO2Script> ().co2Percent = CO2Percents [CO2Index];

		GameObject.Find ("WarningText").GetComponent<Text> ().text = "";
	}

	public void changePressure() {
		pIsBad = !pIsBad;

		if (pIsBad) {
			GameObject.Find ("P").GetComponent<Text> ().text = "Low";
			GameObject.Find ("P").GetComponent<Text> ().color = Color.red;
			GameObject.Find ("PressureAlarm").GetComponent<AlertxTimes> ().playAlert();

		} else {
			GameObject.Find ("P").GetComponent<Text> ().text = "Good";
			GameObject.Find ("P").GetComponent<Text> ().color = Color.green;

		}
		GameObject.Find ("WarningText").GetComponent<Text> ().text = "";
	}

	public void changeFuel() {
		lowFuel = !lowFuel;
		
		if (lowFuel) {
			GameObject.Find ("Th%").GetComponent<Text> ().text = "Low";
			GameObject.Find ("Th%").GetComponent<Text> ().color = Color.red;
			GameObject.Find ("LowFuelAlarm").GetComponent<AlertxTimes> ().playAlert();
			
		} else {
			GameObject.Find ("Th%").GetComponent<Text> ().text = "Good";
			GameObject.Find ("Th%").GetComponent<Text> ().color = Color.green;
			
		}
		GameObject.Find ("WarningText").GetComponent<Text> ().text = "";
	}

	public void changeBattery() {
		batteryIndex++;
		
		if (batteryIndex == batteryPercents.Length) {
			batteryIndex = 0;
		}
		
		GameObject.Find ("Bat%").GetComponent<Text> ().text = (batteryPercents [batteryIndex].ToString() + "%");
		GameObject.Find ("Bat%").GetComponent<Text> ().color = colors2 [batteryIndex];
		
		GameObject.Find ("BatteryAlert").GetComponent<BatteryScript> ().batteryPercentLeft = batteryPercents [batteryIndex];
		GameObject.Find ("WarningText").GetComponent<Text> ().text = "";
	}

	public void coolantAlarm() {

		GameObject.Find ("CoolantAlarm").GetComponent<AudioSource> ().Play ();
		GameObject.Find ("WarningText").GetComponent<Text> ().text = "COOLING SYSTEM PROBLEM";
			
	}

	public void lostToolAlarm() {
		
		GameObject.Find ("LostToolAlarm").GetComponent<AudioSource> ().Play ();
		GameObject.Find ("WarningText").GetComponent<Text> ().text = "TOOL DETACHED";
		
	}
}
