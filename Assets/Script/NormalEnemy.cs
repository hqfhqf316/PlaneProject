using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SimpleFactory
{
    public class NormalEnemy : EnemyBase
    {
        [SerializeField]
        private float repeatRate = 0.3f;
        private void Start()
        {
            InvokeRepeating("Attack", 0f, repeatRate);
        }


        public void Update()
        {
            
            Move();
            if (transform.position.y<ScreenXY.MinY)
            {
                Destroy(this.gameObject);
            }
        }
       

       protected override void Move()
        {
           
       
            transform.position += new Vector3(1, -1, 0) * speed * Time.deltaTime;
        }
        protected override void Attack()
        {

            // GameObject bulletOBJ = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            //bulletOBJ.transform.rotation = Quaternion.Euler(0, 0, 180);
            if (true)
            {
                Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
            }
           
        }
    }

}