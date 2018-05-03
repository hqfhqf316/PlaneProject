using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SimpleFactory
{
    public class EnemyBoss : EnemyBase
    {


        // private Vector3 direction = Vector3.left;
        //private Director director;
        
        private float enemyspeed = 3;
        private float repeatRate=0.3f;
        private void Start()
        {
            InvokeRepeating("Attack", 0f, repeatRate);
        }

        public void Update()
        {
           
            Move();
            
        }
        
       
        protected override void Move()
        {
            
            transform.position += bossdirection * enemyspeed * Time.deltaTime;
            if (transform.position.x - ScreenXY.MinX < 0.3 || (transform.position.x > 0 && transform.position.x - ScreenXY.MaxX > -0.3))
            {
                bossdirection *= -1;
            }
        }
        protected override void Attack()
        {
            //GameObject bulletOBJ = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
           // bulletOBJ.transform.rotation = Quaternion.Euler(0, 0, 180);
            Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
          
        }
    }

}