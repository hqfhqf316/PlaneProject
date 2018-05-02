using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlane : MonoBehaviour,IHealth {
   
    [SerializeField]
    private int health = 5;
    [SerializeField]
    private float speed=5;
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
        InputManger.Instance.OnSpace += FireOnce;
        InputManger.Instance.OnSpaceDown += FireOnce;
        InputManger.Instance.OnMovement += Move;

    }
    private void OnDisable()
    {
        InputManger.Instance.OnSpace -= FireOnce;
        InputManger.Instance.OnSpaceDown -= FireOnce;
        InputManger.Instance.OnMovement -= Move;
    }
    void Update () {
       
       
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
       // playerweapon.FireStart();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Mainplanecollision" + collision.gameObject.name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Mainplaintriggle" + collision.gameObject.name);
    }

    public void Attack()
    {
        throw new NotImplementedException();
    }

    public void Destroy()
    {
        throw new NotImplementedException();
    }

    public void Revive()
    {
        throw new NotImplementedException();
    }
}
