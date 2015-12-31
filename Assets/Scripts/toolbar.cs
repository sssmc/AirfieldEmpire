using UnityEngine;
using System.Collections;

public class toolbar : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Object[] roads = Resources.LoadAll ("tile_roads");
		Debug.Log("roads: " + roads[0]);

		Object[] ground = Resources.LoadAll ("tile_ground");
		Debug.Log("roads: " + ground[0]);
		Debug.Log("roads: " + ground[1]);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
