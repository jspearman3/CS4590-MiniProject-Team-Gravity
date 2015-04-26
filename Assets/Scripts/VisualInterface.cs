using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VisualInterface : MonoBehaviour {

	public RectTransform stationMap;
	public RectTransform positionIcon;
	public GameObject player;
	public GameObject station;
	public Sprite[] maps;

	private int mapIndex;

	//X and Y are relative to world space
	private float playerXPos;
	private float playerYPos;
	private float xRefLowerLeft = -1744F;
	private float yRefLowerLeft = -2174F;
	private float xRefUpperRight = 1616F;
	private float yRefUpperRight = 2205F;

	//X and Y are relative to panel (map picture rotated 90 degrees relative to 2D view in scene view)
	private float mapXLength;
	private float mapYLength;


	// Use this for initialization
	void Start () {
		mapXLength = stationMap.rect.width;
		mapYLength = stationMap.rect.height;

		mapIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
		playerXPos = station.transform.InverseTransformPoint(player.transform.position).x;
		playerYPos = station.transform.InverseTransformPoint(player.transform.position).z;

		Vector2 mapCoords = calculateCoords (playerXPos, playerYPos);
		setIconPosition (mapCoords);

		if (Input.GetKeyDown (KeyCode.Tab)) {
			changeMap();
		}
	}

	private Vector2 calculateCoords(float xStationPos, float yStationPos) {

		float normXWorldOffset = (xStationPos - xRefLowerLeft)/(xRefUpperRight - xRefLowerLeft); 
		float normYWorldOffset = (yStationPos - yRefLowerLeft)/(yRefUpperRight - yRefLowerLeft);

		float MapXOffset = normYWorldOffset * mapXLength; 
		float MapYOffset = normXWorldOffset * mapYLength;
		return new Vector2 (MapXOffset, MapYOffset);
	}

	private void setIconPosition(Vector2 mapCoords) {
		Vector2 correctedMapCoords = new Vector2(mapCoords.x, mapYLength - mapCoords.y) - new Vector2 (mapXLength/2, mapYLength/2);
		positionIcon.position = stationMap.TransformPoint(correctedMapCoords);
	}

	private void changeMap() {
		mapIndex++;

		if (mapIndex >= maps.Length) {
			mapIndex = 0;
		}
		Debug.Log ("Map Changed");
		GameObject.Find ("StationMap").GetComponent<Image> ().sprite = maps [mapIndex];
	}
}
