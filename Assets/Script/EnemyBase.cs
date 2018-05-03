using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour,IHealth {

    [SerializeField]
    protected GameObject bulletPrefab;
    [SerializeField]
    protected float speed = 1;
    [SerializeField]
    protected GameObject destroyFX;
    protected Vector3 direction = Vector3.down;
    protected Vector3 bossdirection = Vector3.left;
    private int health = 100;
    public int Health
    {
        
        get
        {
            return health;
        }
    }

    private void Awake()
    {
       
    }
    private void Update()
    {
        Move();
    }
    protected virtual void Move()
    {
        //transform.Translate(direction * Time.deltaTime * speed);
        Debug.Log("abstract Move");
    }
    protected virtual void Attack()
    {
        Debug.Log("abstract Attack");
        //GameObject bulletOBJ = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        // bulletOBJ.transform.rotation = Quaternion.Euler(0, 0, 180);

    }

    public void Damage(int value)
    {
        health -= value;
        if (health<0)
        {
            
            Destroyself();
            return;
        }
    }
    public void Destroyself()
    {
        Instantiate(destroyFX, this.gameObject.transform.position, destroyFX.transform.rotation);
        Destroy(this.gameObject);
    }
}
