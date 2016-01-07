using UnityEngine;
using System.Collections;

public class tileScript: MonoBehaviour {

	public Vector2 tilePosition = new Vector2();
	private GameObject placeTileObject;
	public string name;
	public Sprite icon;
	public bool isHighlighted;
	private Color startColor;
	public bool isMouseOver;
	// Use this for initialization
	void Start () {

		placeTileObject = GameObject.Find ("Scripts");
		startColor = GetComponent<Renderer> ().material.color;
		isHighlighted = false;
		isMouseOver = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isHighlighted == true && isMouseOver == false) 
		{
			isHighlighted = false;
			GetComponent<Renderer> ().material.color = startColor;
		}
	
	}
	void OnMouseExit()
	{
		isMouseOver = false;
	}

	void OnMouseOver()
	{
		isMouseOver = true;
		if (isHighlighted == false) 
		{
			isHighlighted = true;
			GetComponent<Renderer> ().material.SetColor("_Color", new Color(255,0,0,1.0f));
		}
		if (Input.GetMouseButton (0)) 
		{
			placeTileObject.GetComponent<placeTile> ().ReplaceTile (tilePosition);
		}
	}
}
