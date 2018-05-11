using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField]
    private float enemyspeed = 3;
    private Vector3 direction = Vector3.left;
    private Weapon weapon;
    private int health = 10;
    //public WeaponFac enemyweapon;
    //public int Health
    //{
    //    get
    //    {
    //        return health;
    //    }
    //}

    void Start () {
        weapon = GetComponent<Weapon>();
        //enemyweapon = Weapon.CreateWeapon("Enemy");
    }
	
    void Update () {

        //transform.position += direction * enemyspeed * Time.deltaTime;
       // Move();
       // FireStrat();
       
    }
    //private void Move()
    //{
    //    if (transform.position.x - ScreenXY.MinX < 0.3 || (transform.position.x > 0 && transform.position.x - ScreenXY.MaxX > -0.3))
    //    {
    //        direction *= -1;
    //    }
    //}
   
    //public void FireStrat()
    //{
    //    weapon.FireStart();
        
    //}

    //public void Attack()
    //{
    //    throw new NotImplementedException();
    //}

    //public void Destroy()
    //{
    //    throw new NotImplementedException();
    //}

    //public void Revive()
    //{
    //    throw new NotImplementedException();
    //}
}
