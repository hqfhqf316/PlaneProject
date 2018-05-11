using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface CanGetScore
{
    
    int Score { get; }
    void GetScore(int value);


}