using UnityEngine;
using System.Collections;

public class toolbar : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GameObject[] roads = (GameObject[])Resources.LoadAll ("tile_roads");
		Debug.Log("roads: " + roads[0]);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
