using UnityEngine;
using System.Collections;

public class toobarButton : MonoBehaviour {

	public Tile tile;
	public GameObject placeTimeObject;

	// Use this for initialization
	void Start () {
	
		placeTimeObject = GameObject.Find ("Scripts");
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick()
	{
		Debug.Log ("Click");
		placeTimeObject.GetComponent<placeTile> ().currentPlace.prefab = tile.prefab;

	}
}
