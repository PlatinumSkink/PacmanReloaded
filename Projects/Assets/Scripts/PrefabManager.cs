using UnityEngine;
using System.IO;
using System.Collections;

public class PrefabManager : MonoBehaviour {

	Transform[] PrefabList;
	string[] prefabNames;
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadPrefabs(){
		DirectoryInfo dir = new DirectoryInfo("Assets/Resources");
		FileInfo[] info = dir.GetFiles ("*.PREFAB");
		PrefabList = new Transform[info.Length];
		prefabNames = new string[info.Length];
		for(int i=0; i<info.Length;i++){
			string fileName = info[i].Name.Split('.')[0];
			prefabNames[i] = fileName;
			PrefabList[i] = Resources.Load<Transform>(fileName);
		}
	}
	public Transform[] getPrefabs(){
		return PrefabList;
	}

	public Transform FindPrefab(string prefabName){
		int prefabIndex = -1;
		for(int i=0;i<prefabNames.Length;i++){
			if(prefabName == prefabNames[i])
				prefabIndex = i;
		}
		return PrefabList[prefabIndex];
	}
}
