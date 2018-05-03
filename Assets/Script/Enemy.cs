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
    
    void Start () {
        weapon = GetComponent<Weapon>();
        
    }
	
  
}
