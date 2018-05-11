using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface IHealth { 

	int Health { get; }
    void Damage(int value);
    
    
}
