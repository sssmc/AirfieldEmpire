using UnityEngine;
using System.Collections;

public class objectPreview : MonoBehaviour {

	private GameObject currentPreviewObject;

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
}
