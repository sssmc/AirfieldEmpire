using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class toolbar : MonoBehaviour {

	public GameObject toolbarButton;
	public GameObject toolbarCanvas;
	public int buttonXOffset;
	public int buttonYOffset;

	// Use this for initialization
	void Start () {

		Object[] roads = Resources.LoadAll ("tile_roads");
		Object[] ground = Resources.LoadAll ("tile_ground");

		for (int i = 0; i < ground.Length; i++) 
		{
			GameObject button = Instantiate(toolbarButton);
			button.transform.SetParent(toolbarCanvas.transform);
			RectTransform buttonTransform = button.GetComponent<RectTransform>();
			if(i == 0)
			{
				buttonTransform.anchoredPosition = new Vector2 (buttonXOffset, buttonYOffset);
			}
			else
			{
				buttonTransform.anchoredPosition = new Vector2 ((buttonTransform.sizeDelta.x + (buttonXOffset * 2)) * (i), buttonYOffset);
			}
			GameObject buttonText = button.transform.GetChild(0).gameObject;
			buttonText.GetComponent<Text>().text = ground[i].ToString();

			button.GetComponent<toobarButton>().tile = (GameObject)ground[i];


		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
