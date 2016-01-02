using UnityEngine;
using System.Collections;

public class objectPreview : MonoBehaviour {

	private GameObject currentPreviewObject;
	public int currentRotation;

	void start()
	{
		currentPreviewObject = null;
	}
	
	public void changePreviewObject(GameObject changeTo)
	{
		if (changeTo != null) {
			Destroy (currentPreviewObject);
			currentPreviewObject = (GameObject) Instantiate (changeTo, new Vector3 (0, 10000, 0), this.transform.rotation);
		} 
		else 
		{
			Destroy (currentPreviewObject);
		}
	}
	public void changePreviewObjectRotation (int rotation)
	{
		Debug.Log("change rotation");
		Destroy (currentPreviewObject);
		currentPreviewObject = (GameObject) Instantiate (currentPreviewObject, new Vector3 (0, 10000, 0), Quaternion.Euler(Vector3.up * (90 * rotation)));
		currentPreviewObject.name = "preview object";
	}
}
