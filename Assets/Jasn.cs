using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Jasn : MonoBehaviour
{
    public GameData gamedata;
    private void Start()
    {
       // PlayerData playerData = new PlayerData() { name = "jack", age = 25, isMan = true };
        string myjson = JsonUtility.ToJson(gamedata);
        string filestream = "Assets/playerdata.txt";
        if (File.Exists(filestream))
        {
            Debug.Log("文件已存在");

        }
        else
        {
            FileStream fs = new FileStream(filestream, FileMode.CreateNew);
            var bytes = System.Text.Encoding.UTF8.GetBytes(myjson);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
        }

    }
    
}
