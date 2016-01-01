using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class toolbar : MonoBehaviour {

	public GameObject toolbarButton;
	public GameObject toolbarCanvas;

	public GameObject tabGround;
	public GameObject tabRoads;
	public int buttonXOffset;
	public int buttonYOffset;

	public GameObject startingTab;

	private GameObject currentTab;


	// Use this for initialization
	void Start () {

		addButtons (tabGround, "tile_ground");
		addButtons (tabRoads, "tile_roads");

		currentTab = startingTab;
		currentTab.SetActive (true);

	}

	public void addButtons(GameObject pannel, string assetFolderName)
	{
		Object[] tiles = Resources.LoadAll (assetFolderName);
		
		for (int i = 0; i < tiles.Length; i++) 
		{
			GameObject button = Instantiate(toolbarButton);
			button.transform.SetParent(pannel.transform);
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
			GameObject buttonIcon = button.transform.GetChild(1).gameObject;
			toobarButton toolbarButtonScript = button.GetComponent<toobarButton>();
			
			toolbarButtonScript.tile = new Tile();
			toolbarButtonScript.tile.prefab = (GameObject)tiles[i];
			toolbarButtonScript.tile.name = toolbarButtonScript.tile.prefab.GetComponent<tileScript>().name;
			
			buttonText.GetComponent<Text>().text = toolbarButtonScript.tile.name;
			
			buttonIcon.GetComponent<Image>().sprite = toolbarButtonScript.tile.prefab.GetComponent<tileScript>().icon;
			
			
		}
	}

	public void changeTab (GameObject toChange)
	{

		Debug.Log ("click");
		if (currentTab != toChange) 
		{
			currentTab.SetActive (false);
			currentTab = toChange;
			currentTab.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
