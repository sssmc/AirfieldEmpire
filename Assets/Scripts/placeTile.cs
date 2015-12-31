using UnityEngine;
using System.Collections;

public class placeTile : MonoBehaviour {

	// Use this for initialization
	public GameObject grass;
	public int offset;
	public Vector2 worldSize;
	GameObject[,] tiles;
	void Start () {

		tiles = new GameObject[(int)worldSize.x,(int)worldSize.y];

		for (int i = 0; i < (int)worldSize.x; i++) 
		{
			for(int r = 0; r < (int)worldSize.y; r++)
			{
				tiles[i,r] = (GameObject)Instantiate(grass, new Vector3(offset * r, 0.0f, offset * i), this.transform.rotation);
				tiles[i,r].GetComponent<Tile>().tilePosition = new Vector2(i,r);
				//tiles[i,r].transform.Rotate(-90,0,0);
			}
		}


	}

	// Update is called once per frame
	void Update () {
	
	}

	public void ReplaceTile(Vector2 tileLocation)
	{
		Destroy(tiles[(int)tileLocation.x, (int)tileLocation.y]);

	}
}
