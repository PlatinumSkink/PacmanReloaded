using UnityEngine;
using System.Collections;

public class LevelHandlerScript : MonoBehaviour {

	public Transform TilePrefab;
	public Transform WallPrefab;
	public Texture2D LevelMap;
	public Rect sRect;

	Color[] tileMapKey = {Color.white, Color.black};
	int[,] tileMap;
	int level = 0;

	// Use this for initialization
	void Start () {
		int width = Mathf.FloorToInt(sRect.width);
		int height = Mathf.FloorToInt(sRect.height);
		int x = Mathf.FloorToInt(sRect.x) + width * level;
		int y = Mathf.FloorToInt (sRect.y) + height*level / 4;
			tileMap = new int[width,height];
		Color[] mapColors = LevelMap.GetPixels(x,y,width,height);
		for(int i=0;i<height;i++){
			for(int j=0;j<width;j++){
				print (width*i+j);
				for(int index=0;index<tileMapKey.Length;index++){
					if(tileMapKey[index] == mapColors[width*i+j]){
						tileMap[j,i] = index;
						print (i + "/" + j + ":" + index);
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
	
	// Update is called once per frame
	void Update () {
	
	}
}
