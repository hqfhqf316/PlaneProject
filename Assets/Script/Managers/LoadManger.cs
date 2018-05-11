using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadManger : MonoBehaviour {
    public static void LoadScene(string name)
    {
        LoadScene(SceneUtility.GetBuildIndexByScenePath(name));
    }
    public static void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
    }
}
