using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {


	public int moveSpeed;
	public int zoomSpeed;
	public Vector3 moveTarget;
	public float zoomSmoothAmount;
	public float moveSmoothAmount;
	// Use this for initialization

	void Start () {

		moveTarget = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.W)) 
		{
			moveTarget += Vector3.forward * moveSpeed;
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			moveTarget += Vector3.back * moveSpeed;
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			moveTarget += Vector3.left * moveSpeed;
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			moveTarget += Vector3.right * moveSpeed;
		}

		if (Input.GetAxis ("Mouse ScrollWheel") < 0) 
		{
			moveTarget += Vector3.up * zoomSpeed;
		}
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) 
		{
			moveTarget += Vector3.down * zoomSpeed;
		}

		transform.position = new Vector3(transform.position.x, Vector3.Lerp(transform.position, moveTarget, zoomSmoothAmount * Time.deltaTime).y, transform.position.z);

		transform.position = new Vector3(Vector3.Lerp(transform.position, moveTarget, moveSmoothAmount * Time.deltaTime).x, transform.position.y, Vector3.Lerp(transform.position, moveTarget, moveSmoothAmount * Time.deltaTime).z);
	
	}
}
