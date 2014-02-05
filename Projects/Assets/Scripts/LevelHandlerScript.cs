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
			Destroy (transform.GetChild(0)); //tar bort alla nuvarande tiles på kartan.
		}
		Rect sRect = new Rect(0,0,0,0); //sourceRectangle; bestämmer vart på texturen som ska läsas av.
		sRect.width = LevelMap.width / (levelCount); //Bestämmer bredden på sourceRectangle. Häri ligger begränsningen att alla kartor måste vara lika stora.
		sRect.height = LevelMap.height;
		int width = Mathf.FloorToInt(sRect.width);
		int height = Mathf.FloorToInt(sRect.height);
		int x = Mathf.FloorToInt(sRect.x + width * nLevel); //Förskjuter sRect till höger baserat på nuvarande level
		int y = Mathf.FloorToInt (sRect.y);
		print (x + ":" + y + ":" + width + ":" + height);
		tileMap = new int[width,height]; //Skapar en karta av siffror som indikerar vilken tile som ska placeras vid den positionen
		Color[] mapColors = LevelMap.GetPixels(x,y,width,height); //Läser av kartan, sparar pixeldata i en array med färger.
		for(int i=0;i<height;i++){
			for(int j=0;j<width;j++){
				for(int index=0;index<tileMapKey.Length;index++){
					if(tileMapKey[index] == mapColors[width*i+j]){
						tileMap[j,i] = index; //Loopar igenom mapColors, jämför dem med varje färg i tileMapKey (ovan). Rätt färg ger rätt siffra i tileMap.
					}
				}
			}
		}
		for(int i=0; i<width;i++){
			for(int j=0;j<height;j++){
				//Loopar igenom tileMap, utför olika instruktioner beroende på tileMaps värde. 0 är väg, 1 är vägg.
				Vector3 tilePosition = new Vector3(10 + j, 0, 10 + i);
				if(tileMap[i,j] == 0){
					tilePosition.y = TilePrefab.localScale.y / 2; // Justering för origin. Annars skulle alla tiles ligga halvvägs under banan.
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
		level = nLevel;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
