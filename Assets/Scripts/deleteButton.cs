using UnityEngine;
using System.Collections;

public class deleteButton : MonoBehaviour {

	public GameObject emptyTile;
	private GameObject scriptObject;

	void Start()
	{
		scriptObject = GameObject.Find ("Scripts");
	}
	
	// Update is called once per frame
	public void onClick()
	{
		Debug.Log ("delete");
		scriptObject.GetComponent<placeTile> ().currentPlace.prefab = emptyTile;
	}
}
