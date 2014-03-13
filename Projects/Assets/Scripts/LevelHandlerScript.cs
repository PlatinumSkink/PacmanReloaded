using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class LevelHandlerScript : MonoBehaviour {
	
	public int level = 0;
	public int candies = 1;
	public Transform player;
	Transform[] PrefabList;
	int[,] tileMap;
	MapManager mapManager;
	PrefabManager prefabManager;

	// Use this for initialization
	void Start () {
		mapManager = GetComponent<MapManager>();
		prefabManager = GetComponent<PrefabManager>();
		mapManager.ReadFiles();
		prefabManager.LoadPrefabs();
		PrefabList = prefabManager.getPrefabs();
		SetLevel (level);
	}

	void SetLevel(int nLevel){
		if(transform.childCount > 0){
		List<GameObject> children = new List<GameObject>();
		foreach(Transform child in transform) children.Add(child.gameObject);
		foreach(GameObject child in children) Destroy (child);
		}
		tileMap = mapManager.GetLevelInfo(nLevel); //Hämtar info från TextureManager gällande kartan.
		int width = tileMap.GetUpperBound(0);
		int height = tileMap.GetUpperBound(1);
		Vector2 center = new Vector2(width / 2, height / 2);
		for(int i=0; i<width;i++){
			for(int j=0;j<height;j++)
			{
				//Loopar igenom tileMap, utför olika instruktioner beroende på tileMaps värde. 1 är väg, 2 är vägg.
				Vector3 tilePosition = new Vector3(i, 0, j);
				if(tileMap[i,j] > 0){
					//print(PrefabList.Length);
				Transform curPrefab = PrefabList[tileMap[i,j] - 1];
					tilePosition.y = curPrefab.localScale.y / 2;
				Transform tile = (Transform) Instantiate(curPrefab, tilePosition, Quaternion.identity);
					if(tile.GetComponent<CandySpawner>()){
						Transform prefab = prefabManager.FindPrefab("X_CandyPrefab");
						tile.GetComponent<CandySpawner>().PlaceCandy((new Vector2(i,j) - center).magnitude, center.magnitude, prefab);
					}
					if(tile.GetComponent<TeleporterScript>()){
						int x = tileMap[i, j];
						TeleporterManager.AddTeleporter(x, tile, player, this);
					}
				tile.parent = transform;
				}
			}
		}
		level = nLevel;

		//Niklas adds, the ghosts need to know the corners of the new map.
		GetComponent<GhostManager> ().SetScatterPoints (width, height);

		candies = GetNumberOfCandies ();
		player.audio.Play ();
	}

	public int GetPositionInfo(float x, float z){
		int a = Mathf.RoundToInt(x);
		int b = Mathf.RoundToInt(z);
		return tileMap[a,b];
	}
	
	public int GetPositionInfo (Vector3 position){
		int x = Mathf.RoundToInt(position.x);
		int y = Mathf.RoundToInt(position.z);
		return tileMap[x,y];
	}

	public int GetGameObjectPositionInfo(GameObject g){
		int x = Mathf.RoundToInt(g.transform.position.x);
		int y = Mathf.RoundToInt(g.transform.position.z);
		return tileMap[x,y];
	}

	public int GetLevelWidth()
	{
		return tileMap.GetLength(0);
	}

	public int GetLevelDepth()
	{
		return tileMap.GetLength(1);
	}

	public int GetNumberOfCandies()
	{
		GameObject[] objectList;
		objectList = GameObject.FindGameObjectsWithTag ("Candy");
		int amount = objectList.Length;
		return amount;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Q)){
			SetLevel(0);
		}
		else if(Input.GetKeyDown(KeyCode.E)){
			SetLevel(1);
		}
		else if(Input.GetKeyDown(KeyCode.R)){
			GetGameObjectPositionInfo(GameObject.Find ("Player"));
		}
	}
}
