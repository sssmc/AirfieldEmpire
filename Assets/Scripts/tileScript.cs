using UnityEngine;
using System.Collections;

public class tileScript: MonoBehaviour {

	public Vector2 tilePosition = new Vector2();
	private GameObject placeTileObject;
	public string name;
	public Sprite icon;
	// Use this for initialization
	void Start () {

		placeTileObject = GameObject.Find ("Scripts");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButton (0)) 
		{
			placeTileObject.GetComponent<placeTile> ().ReplaceTile (tilePosition);
		}
	}
}
