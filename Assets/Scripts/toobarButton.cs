using UnityEngine;
using System.Collections;

public class toobarButton : MonoBehaviour {

	public Tile tile;
	public GameObject scriptObject;

	// Use this for initialization
	void Start () {
	
		scriptObject = GameObject.Find ("Scripts");
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick()
	{
		Debug.Log ("Click");
		scriptObject.GetComponent<placeTile> ().currentPlace.prefab = tile.prefab;
		scriptObject.GetComponent<objectPreview> ().changePreviewObject (tile.prefab);

	}
}
