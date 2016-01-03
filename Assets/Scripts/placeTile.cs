using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class placeTile : MonoBehaviour {

	// Use this for initialization
	public GameObject grass;
	public int offset;
	public Vector2 worldSize;

	Tile[,] tiles;

	public int currentRotation;

	public GameObject startingTile;

	public Tile currentPlace;

	public int brushSize;
	public int maxBrushSize;
	public GameObject brushSizeText;
	public GameObject placeParticle;

	void Start () {

		currentRotation = 0;

		brushSize = 0;

		tiles = new Tile[(int)worldSize.x,(int)worldSize.y];

		currentPlace = new Tile ();
		currentPlace.prefab = startingTile;

		this.GetComponent<objectPreview> ().changePreviewObject (currentPlace.prefab);

		for (int i = 0; i < (int)worldSize.x; i++) 
		{
			for(int r = 0; r < (int)worldSize.y; r++)
			{
				tiles[i,r] = new Tile();
				tiles[i,r].prefab = (GameObject)Instantiate(grass, new Vector3(offset * r, 0.0f, offset * i), this.transform.rotation);

				tiles[i,r].prefab.GetComponent<tileScript>().tilePosition = new Vector2(i,r);
				//tiles[i,r].transform.Rotate(-90,0,0);
			}
		}


	}

	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.R)) 
		{
			if(currentRotation != 3)
			{
				currentRotation ++;
			}
			else
			{
				currentRotation = 0;
			}

			this.GetComponent<objectPreview>().changePreviewObjectRotation(currentRotation);

		}
		if (Input.GetKeyDown (KeyCode.Period)) 
		{
			if(brushSize < maxBrushSize)
			{
				brushSize ++;
				brushSizeText.GetComponent<Text>().text = ("Brush Size: " + (brushSize * 2));
			}
		}
		if (Input.GetKeyDown (KeyCode.Comma)) 
		{
			if(brushSize > 0)
			{
				brushSize --;
				brushSizeText.GetComponent<Text>().text = ("Brush Size: " + (brushSize * 2));
			}
		}


	
	}

	public void ReplaceTile(Vector2 tileLocation)
	{
		if (brushSize == 0) {
			Tile currentTile = tiles [(int)tileLocation.x, (int)tileLocation.y];
			Destroy (currentTile.prefab);
			currentTile.prefab = (GameObject)Instantiate (currentPlace.prefab, new Vector3 (offset * (int)tileLocation.y, 0.0f, offset * (int)tileLocation.x), this.transform.rotation);

			Destroy(Instantiate(placeParticle, new Vector3 (offset * (int)tileLocation.y, -1.0f, offset * (int)tileLocation.x), this.transform.rotation), 2.2f);

			currentTile.prefab.transform.Rotate (Vector3.up * (90 * currentRotation));

			currentTile.prefab.GetComponent<tileScript> ().tilePosition = new Vector2 ((int)tileLocation.x, (int)tileLocation.y);
		} 
		else 
		{
			Vector2 centerLocation = new Vector2(tileLocation.x * offset, tileLocation.y * offset);
			Vector2 bottomLeftCornerTile = new Vector2(tileLocation.x - brushSize, tileLocation.y - brushSize);

			for(int r = 0; r < (brushSize * 2) + 1; r++)
			{
				for(int c = 0; c < (brushSize * 2) + 1; c++)
				{
					if(bottomLeftCornerTile.x + r >= 0 || bottomLeftCornerTile.y + c >= 0)
					{
						if(bottomLeftCornerTile.x + r >= 0 && bottomLeftCornerTile.y + c >= 0)
						{
							if(bottomLeftCornerTile.x + r < worldSize.x || bottomLeftCornerTile.y + c < worldSize.y)
							{
								if(bottomLeftCornerTile.x + r < worldSize.x && bottomLeftCornerTile.y + c < worldSize.y)
								{
									if(Vector3.Distance(new Vector3(centerLocation.x, 0.0f, centerLocation.y), new Vector3(offset * ((int)bottomLeftCornerTile.x + r), 0.0f, offset * ((int)bottomLeftCornerTile.y + c))) < offset * brushSize)
									{
										Destroy(tiles[(int)bottomLeftCornerTile.x + r, (int)bottomLeftCornerTile.y + c].prefab);
										tiles[(int)bottomLeftCornerTile.x + r, (int)bottomLeftCornerTile.y + c].prefab = (GameObject)Instantiate (currentPlace.prefab, new Vector3 (offset * ((int)bottomLeftCornerTile.y + c), 0.0f, offset * ((int)bottomLeftCornerTile.x + r)), this.transform.rotation);

										Destroy((GameObject)Instantiate (placeParticle, new Vector3 (offset * ((int)bottomLeftCornerTile.y + c), -1.0f, offset * ((int)bottomLeftCornerTile.x + r)), this.transform.rotation), 2.2f);

										tiles[(int)bottomLeftCornerTile.x + r, (int)bottomLeftCornerTile.y + c].prefab.transform.Rotate (Vector3.up * (90 * currentRotation));
										
										tiles[(int)bottomLeftCornerTile.x + r, (int)bottomLeftCornerTile.y + c].prefab.GetComponent<tileScript> ().tilePosition = new Vector2 ((int)bottomLeftCornerTile.x + r, (int)bottomLeftCornerTile.y + c);
									}
								}
							}
						}
					}

				}
			}

		}

	}
}
