using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlane : MonoBehaviour,IHealth {
   
    [SerializeField]
    private int health = 300;
    [SerializeField]
    private float speed=5;
    [SerializeField]
    protected GameObject explosionFX;
    private Vector3 direction;
    private float timer;
    private float MaxX;
    private float MinX;
    private float MaxY;
    private float MinY;
   
    private Weapon weapon;
   // public WeaponFac playerweapon;
    public int Health
    {
        get
        {
            return health;
        }
    }

    
    private void Awake()
    {
       weapon = GetComponent<Weapon>();
      // playerweapon = Weapon.CreateWeapon("Player");
    }
    void Start () {
        MaxX = ScreenXY.MaxX;
        MaxY = ScreenXY.MaxY;
        MinX = ScreenXY.MinX;
        MinY = ScreenXY.MinY;
	}
    private void OnEnable()
    {
        if (InputManger.Instance)
        {
            InputManger.Instance.OnSpace += FireOnce;
            InputManger.Instance.OnSpaceDown += FireOnce;
            InputManger.Instance.OnMovement += Move;
        }
    }
    private void OnDisable()
    {
        if (InputManger.Instance)
        {
            InputManger.Instance.OnSpace -= FireOnce;
            InputManger.Instance.OnSpaceDown -= FireOnce;
            InputManger.Instance.OnMovement -= Move;
        }
    }
    void Update ()
    {
       ClamFrame();
    }
    private void Move(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    private void ClamFrame()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX,MaxX),
            Mathf.Clamp(transform.position.y, MinY, MaxY),
            transform.position.z);
    }
    private void FireOnce()
    {
       weapon.FireOnce();
       // playerweapon.FireOnce();
    }
    private void FireStart()
    {
        weapon.FireStart();
       
    }
    public void Damage(int _value)
    {
        if (health <= 0) return;
        health -= _value;

        if (health <= 0)
        {
            if (AppConst.IsDebugMode==false)
            DestroySelf();
            
        }
    }

    private void DestroySelf()
    {
        Instantiate(explosionFX, this.transform.position, explosionFX.transform.rotation);
        Destroy(this.gameObject);
        
        Debug.Log("you are dead\n please press J to revive");
        Director.Instance.PlayerDead();
    }
}
