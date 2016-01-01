using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public Vector2 tilePosition = new Vector2();
	private GameObject placeTileObject;
	// Use this for initialization
	void Start () {

		placeTileObject = GameObject.Find ("Scripts");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		placeTileObject.GetComponent<placeTile> ().ReplaceTile (tilePosition);
		Debug.Log ("Tile click at: " + tilePosition);
	}
}
