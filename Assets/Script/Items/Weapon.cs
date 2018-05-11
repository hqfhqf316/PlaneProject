using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform bullets;
    private float timer;

    public void FireOnce()
    {
        if (Time.time - timer > 0.3)
        {
            Instantiate(bullet, transform.position + Vector3.up, Quaternion.identity, bullets);
            timer = Time.time;
        }
    }
    public void FireStart()
    {
        if (Time.time - timer > 0.3)
        {
            Instantiate(bullet, transform.position + Vector3.up, Quaternion.identity, bullets);
            timer = Time.time;
        }

    }
}
//public class Weapon:MonoBehaviour
//{
//    [SerializeField]
//    public GameObject bullet;
//    [SerializeField]
//    public Transform bullets;
//    public static WeaponFac CreateWeapon(string type)
//    {
//        WeaponFac weaponFac = null;
//        if (type.Equals("Enemy"))
//        {
//            weaponFac = new EnemyBase();
//        }
//        else if (type.Equals("Player"))
//        {
//            weaponFac = new Player();
//        }
//        return weaponFac;
//    }

//}
//public abstract class WeaponFac: MonoBehaviour
//{

//    public float timer;
//    public abstract void FireOnce();
//    public abstract void FireStart();
//}
//public class EnemyBase : WeaponFac
//{
//    public override void FireOnce()
//    {
//        if (Time.time - timer > 0.3)
//        {
//            Instantiate(bullet, transform.position + Vector3.down, Quaternion.identity, bullets);
//            timer = Time.time;
//        }
//    }
//        public override void FireStart()
//    {
//        if(Time.time - timer > 0.3)
//        {
//            Instantiate(bullet, transform.position + Vector3.down, Quaternion.identity, bullets);
//            timer = Time.time;
//        }
//    }
//}
//public class Player : WeaponFac
//{
//    public override void FireOnce()
//    {
//        if (Time.time - timer > 0.3)
//        {
//            Instantiate(bullet, transform.position + Vector3.up, Quaternion.identity, bullets);
//            timer = Time.time;
//        }
//    }
//    public override void FireStart()
//    {
//        if (Time.time - timer > 0.3)
//        {
//            Instantiate(bullet, transform.position + Vector3.up, Quaternion.identity, bullets);
//            timer = Time.time;
//        }
//    }
//}