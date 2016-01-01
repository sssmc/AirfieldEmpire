using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {


	public int movementsSpeed;
	public int zoomSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.W)) 
		{
			Debug.Log("move forward");
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + movementsSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			Debug.Log("move backwards");
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - movementsSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			Debug.Log("move left");
			transform.position = new Vector3(transform.position.x - movementsSpeed * Time.deltaTime, transform.position.y, transform.position.z);
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			Debug.Log("move right");
			transform.position = new Vector3(transform.position.x + movementsSpeed * Time.deltaTime, transform.position.y, transform.position.z);
		}

		if (Input.GetAxis ("Mouse ScrollWheel") < 0) 
		{
			Debug.Log("zoom out");
			transform.Translate(-((Vector3.forward * zoomSpeed) * Time.deltaTime));
		}

		if (Input.GetAxis ("Mouse ScrollWheel") > 0) 
		{
			Debug.Log("zoom in");
			transform.Translate((Vector3.forward * zoomSpeed) * Time.deltaTime);
		}
	
	}
}
