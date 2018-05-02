using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SimpleFactory
{
    public class EnemyBoss : EnemyBase
    {


        private Vector3 direction = Vector3.left;
        private Director director;
        private float enemyspeed = 3;
        public void Update()
        {
           
            Move();
            FireStart();
        }
        public override void FireStart()
        {
            
            //director.weapon.FireStart(); //无效
            //print("fire");
        }

        public override void Move()
        {
           // print("movechange"+gameObject.name);  //出现两个gameobject!!
            transform.position += direction * enemyspeed * Time.deltaTime;
            if (transform.position.x - ScreenXY.MinX < 0.3 || (transform.position.x > 0 && transform.position.x - ScreenXY.MaxX > -0.3))
            {
                direction *= -1;
            }
        }
    }

}