
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreDisaple : MonoBehaviour {
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject[] LiftCount;
    private Director director;

    void Start()
    {
        director = Director.Instance;   
    }
    void Update () {
        scoreText.text = director.Score.ToString();
        
        for (int i = 0; i <LiftCount.Length; i++)
        {
            LiftCount[i].SetActive(i < director.PlayerLiftcount);
        }
	}
}
