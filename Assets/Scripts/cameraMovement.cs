using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {


	public int moveSpeed;
	public int zoomSpeed;
	public Vector3 moveTarget;
	public float zoomSmoothAmount;
	public float moveSmoothAmount;
	public int maxZoom;
	public int minZoom;
	public int zoomSpeedDistanceDivider;
	public int moveSpeedDistanceDivider;
	public Camera camera;
	private float mouseRayDistance;
	// Use this for initialization

	void Start () {

		moveTarget = transform.position;

	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKey (KeyCode.W)) 
		{
			moveTarget += Vector3.forward * (moveSpeed * (mouseRayDistance / moveSpeedDistanceDivider));
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			moveTarget += Vector3.back * (moveSpeed * (mouseRayDistance / moveSpeedDistanceDivider));
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			moveTarget += Vector3.left * (moveSpeed * (mouseRayDistance / moveSpeedDistanceDivider));
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			moveTarget += Vector3.right * (moveSpeed * (mouseRayDistance / moveSpeedDistanceDivider));
		}

		if (Input.GetAxis ("Mouse ScrollWheel") < 0) 
		{
			moveTarget += Vector3.up * (zoomSpeed * (mouseRayDistance / zoomSpeedDistanceDivider));
		}
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) 
		{
			moveTarget += Vector3.down * (zoomSpeed * (mouseRayDistance / zoomSpeedDistanceDivider));
		}

		transform.position = new Vector3(transform.position.x, Vector3.Lerp(transform.position, moveTarget, zoomSmoothAmount * Time.deltaTime).y, transform.position.z);

		transform.position = new Vector3(Vector3.Lerp(transform.position, moveTarget, moveSmoothAmount * Time.deltaTime).x, transform.position.y, Vector3.Lerp(transform.position, moveTarget, moveSmoothAmount * Time.deltaTime).z);

		transform.position = new Vector3(transform.position.x, Mathf.Clamp (transform.position.y, minZoom, maxZoom), transform.position.z);
		moveTarget.y = Mathf.Clamp (moveTarget.y, minZoom, maxZoom);

		RaycastHit hit;
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		
		if (Physics.Raycast(ray, out hit)) {
			Transform objectHit = hit.transform;
			
			mouseRayDistance = hit.distance;
		}
	
	}
}
