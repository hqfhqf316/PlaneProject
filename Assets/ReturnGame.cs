using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayGame();
           
        }

    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);

    }
    public void GotoMenu()
    {
        StartCoroutine(Menu());
    }

    private IEnumerator Menu()
    {
        Uimanger.Instance.FadeOn(true);
        yield return new WaitForSeconds(1f);
        LoadManger.LoadScene(0);

    }
}
