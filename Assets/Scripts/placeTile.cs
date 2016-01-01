using UnityEngine;
using System.Collections;

public class placeTile : MonoBehaviour {

	// Use this for initialization
	public GameObject grass;
	public int offset;
	public Vector2 worldSize;
	Tile[,] tiles;

	public GameObject startingTile;

	public Tile currentPlace;

	void Start () {

		tiles = new Tile[(int)worldSize.x,(int)worldSize.y];

		currentPlace = new Tile ();
		currentPlace.prefab = startingTile;

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
	
	}

	public void ReplaceTile(Vector2 tileLocation)
	{
		Destroy(tiles[(int)tileLocation.x, (int)tileLocation.y].prefab);
		tiles[(int)tileLocation.x, (int)tileLocation.y].prefab = (GameObject)Instantiate(currentPlace.prefab, new Vector3(offset * (int)tileLocation.y, 0.0f, offset * (int)tileLocation.x), this.transform.rotation);
		tiles[(int)tileLocation.x,(int)tileLocation.y].prefab.GetComponent<tileScript>().tilePosition = new Vector2((int)tileLocation.x,(int)tileLocation.y);

	}
}
