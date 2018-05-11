using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;
public class Gold : MonoBehaviour, CanGetScore
{

    private Director director;
    public int goldscore = 50;
    private int goldespeed = 3;
    private Collider2D coll;
    private Renderer rend;
   
    private AudioSource source;
    void Awake()
    {
        coll = GetComponent<Collider2D>();
        rend = GetComponent<Renderer>();
        director = Director.Instance;
       source = GetComponent<AudioSource>();
    }
    public void Update()
    {
        transform.position += Vector3.down * goldespeed * Time.deltaTime;
        if (transform.position.y < ScreenXY.MinY)
        {
            Destroy(this.gameObject);
        }

    }
    public int Score
    {
        get
        {
            return goldscore;
        }
    }
    public void GetScore(int value)
    {
        director.Score += value;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            source.Play();
            coll.enabled = false;
            rend.enabled = false;
            Destroy(this.gameObject,source.clip.length);
            
            GetScore(goldscore);
        }
    }
}
