
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IHealth, CanGetScore
{

    [SerializeField]
    protected GameObject bulletPrefab;
    [SerializeField]
    protected float speed = 1;
    [SerializeField]
    protected GameObject destroyFX;
    private Director director;
    protected Vector3 direction = Vector3.down;
    protected Vector3 bossdirection = Vector3.left;
    private int health = 100;
    private int score = 100;

    private void Awake()
    {
        director = Director.Instance;
    }
    public int Health
    {

        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }
    }
    public void GetScore(int value)
    {
      
        director.Score += score;
    }
    private void Update()
    {
        Move();
    }
    protected virtual void Move()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }
    protected virtual void Attack()
    {
        GameObject bulletOBJ = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletOBJ.transform.rotation = Quaternion.Euler(0, 0, 180);
    }

    public void Damage(int value)
    {
        health -= value;
        if (health < 0)
        {
            Destroyself();
            GetScore(score);
            return;
        }
    }
    public void Destroyself()
    {
        Instantiate(destroyFX, this.gameObject.transform.position, destroyFX.transform.rotation);
        Destroy(this.gameObject);
    }

}
