using UnityEngine;
using System.Collections;

public class LevelHandlerScript : MonoBehaviour {

	public Transform TilePrefab;
	public Transform WallPrefab;
	public Texture2D LevelMap;
	public int level = 0;
	public int levelCount = 2;

	Color[] tileMapKey = {Color.white, Color.black};
	int[,] tileMap;

	// Use this for initialization
	void Start () {
		SetLevel (level);
	}

	void SetLevel(int nLevel){
		for(int i=0;i<transform.childCount;i++){
			Destroy (transform.GetChild(0));
		}
		Rect sRect = new Rect(0,0,0,0);
		Vector2 dimFactors = texDimension (levelCount, false);
		Vector2 lvlAdjust = texDimension(nLevel,true);
		sRect.width = LevelMap.width / dimFactors.x;
		sRect.height = LevelMap.height / dimFactors.y;
		int width = Mathf.FloorToInt(sRect.width);
		int height = Mathf.FloorToInt(sRect.height);
		int x = Mathf.FloorToInt(sRect.x + width * lvlAdjust.x);
		int y = Mathf.FloorToInt (sRect.y + height*lvlAdjust.y);
		print (x + ":" + y + ":" + width + ":" + height);
		tileMap = new int[width,height];
		Color[] mapColors = LevelMap.GetPixels(x,y,width,height);
		for(int i=0;i<height;i++){
			for(int j=0;j<width;j++){
				for(int index=0;index<tileMapKey.Length;index++){
					if(tileMapKey[index] == mapColors[width*i+j]){
						tileMap[j,i] = index;
					}
				}
			}
		}
		for(int i=0; i<width;i++){
			for(int j=0;j<height;j++){
				Vector3 tilePosition = new Vector3(10 + j, 0, 10 + i);
				if(tileMap[i,j] == 0){
					tilePosition.y = TilePrefab.localScale.y / 2;
					Transform tile = (Transform) Instantiate (TilePrefab,tilePosition,Quaternion.identity);
					tile.parent = transform;
				}
				else if(tileMap[i,j] == 1){
					tilePosition.y = WallPrefab.localScale.y / 2;
					Transform tile = (Transform) Instantiate (WallPrefab,tilePosition,Quaternion.identity);
					tile.parent = transform;
				}
			}
		}
	}

	Vector2 texDimension(int index, bool isPoint){
		Vector2 returnVec = Vector2.zero;
		if(isPoint){
			returnVec.x = index % 4;
			returnVec.y = (index - index % 4) / 4;}
		else{
			returnVec.x = Mathf.Min(index, 4);
			returnVec.y = (index - index % 4) / 4 + 1;
		}
		return returnVec;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
