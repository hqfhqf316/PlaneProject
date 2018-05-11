using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SimpleFactory
{
    public class NormalEnemy : EnemyBase
    {

        private Vector3 direction = Vector3.left;
        private Director director;
        public void Update()
        {
            FireStart();
            Move();
            if (transform.position.x>ScreenXY.MaxX)
            {
                Destroy(this.gameObject);
            }
        }
        public override void FireStart()
        {
            //director.weapon.FireStart();  //武器系统失效

        }

        public override void Move()
        {
            transform.position += new Vector3(1, -1, 0) * 3 * Time.deltaTime;
        }
    }

}