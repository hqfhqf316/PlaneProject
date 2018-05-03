using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace SimpleFactory
{
    public class Director : MonoBehaviour
    {
        private float timer=0;
        private EnemySimpleFactory enemySimpleFactory;
        void Awake()
        {
            
            enemySimpleFactory = new EnemySimpleFactory();
            enemySimpleFactory.CreateEnemy("EnemyBoss");

           
            enemySimpleFactory.CreateEnemy("NormalEnemy");

        }
        //private void Update()
        //{
        //    timer += Time.deltaTime;
        //    if (timer>5)
        //    {
        //        //EnemyBase normalenemy1 = EnemySimpleFactory.CreateEnemy("NormalEnemy");
        //        enemySimpleFactory.CreateEnemy("NormalEnemy");
        //        timer = 0;
        //    }


        //}

    }

}