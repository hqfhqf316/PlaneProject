using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ReadFile : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        string s = File.ReadAllText("Assets/playerdata.txt", System.Text.Encoding.UTF8);
        s = s.Replace("\r", "");
        s = s.Replace("\n", "");
       // PlayerData data = JsonUtility.FromJson<PlayerData>(s);
        //print(data.name + "\n" + data.age);
       // GameData data = JsonUtility.FromJson<GameData>(s);
       // print(data.fxvolum);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
