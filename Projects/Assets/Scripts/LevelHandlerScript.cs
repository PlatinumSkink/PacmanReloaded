﻿using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class LevelHandlerScript : MonoBehaviour {
	
	public int level = 0;

	Transform[] PrefabList;
	int[,] tileMap;
	MapManager mapManager;

	// Use this for initialization
	void Start () {
		mapManager = GetComponent<MapManager>();
		mapManager.ReadFiles();
		LoadPrefabs();
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
		for(int i=0; i<width;i++){
			for(int j=0;j<height;j++)
			{
				//Loopar igenom tileMap, utför olika instruktioner beroende på tileMaps värde. 1 är väg, 2 är vägg.
				Vector3 tilePosition = new Vector3(i, 0, j);
				if(tileMap[i,j] > 0){
				Transform curPrefab = PrefabList[tileMap[i,j] - 1];
					tilePosition.y = curPrefab.localScale.y / 2;
				Transform tile = (Transform) Instantiate(curPrefab, tilePosition, Quaternion.identity);
				tile.parent = transform;
				}
			}
		}
		level = nLevel;
	}

	void LoadPrefabs(){
		DirectoryInfo dir = new DirectoryInfo("Assets/Resources");
		FileInfo[] info = dir.GetFiles ("*.PREFAB");
		PrefabList = new Transform[info.Length];
		for(int i=0; i<info.Length;i++){
			string fileName = info[i].Name.Split('.')[0];
			PrefabList[i] = Resources.Load<Transform>(fileName);
		}
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Q)){
			SetLevel(0);
		}
		else if(Input.GetKeyDown(KeyCode.E)){
			SetLevel(1);
		}
	}
}
