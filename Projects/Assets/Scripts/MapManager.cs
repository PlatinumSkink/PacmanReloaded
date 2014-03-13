using UnityEngine;
using System.IO;
using System.Collections;

public class MapManager : MonoBehaviour {

	Texture2D[] mapTextures;
	int[][,] tileMaps;
	Color[] tileMapKey = {Color.red, Color.white, Color.black, Color.cyan, Color.green, Color.blue, Color.magenta};
	//I ordning: 0: tomt block, 1:väg, 2: vägg, 3: startpunkt (PacMan), 4: teleporter (grön), 5: teleporter (blå), 6: startplats för spöken

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ReadFiles(){
			DirectoryInfo dir = new DirectoryInfo("Assets/Resources");
			FileInfo[] info = dir.GetFiles("*.bmp");
			mapTextures = new Texture2D[info.Length];
			tileMaps = new int[info.Length][,];
			for(int i=0; i<info.Length;i++){
				string fileName = info[i].Name.Split('.')[0];
				mapTextures[i] = Resources.Load<Texture2D>(fileName);
			Vector2 dimVectors = new Vector2(mapTextures[i].width,mapTextures[i].height);
				tileMaps[i] = new int[(int)dimVectors.x+1,(int)dimVectors.y+1];
				Color[] mapColors = mapTextures[i].GetPixels();
				for(int j=0; j<mapColors.Length;j++)
				{
					int x = j % (int) dimVectors.x;
					int y = (j - x) / (int)dimVectors.x;
					for(int k=0;k<tileMapKey.Length;k++){
					if(mapColors[j] == tileMapKey[k]){
							tileMaps[i][x,y] = k;
						}
					}
				}
			}
		}


	public int[,] GetLevelInfo(int index){

		return tileMaps[index];
	}
}
