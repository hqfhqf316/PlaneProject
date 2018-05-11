using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace SimpleFactory
{
    public class Director : MonoBehaviour
    {
        [SerializeField]
        private GameObject Boss;
        [SerializeField]
        private GameObject NormalEnemy;
        [SerializeField]
        public Weapon weapon;
        private float timer=0;
         void Main()
        {
           
            EnemyBase boss = EnemySimpleFactory.CreateEnemy("Boss");
            Instantiate(Boss, new Vector3(0, 4, 0), Quaternion.identity);
           // boss.transform.position = new Vector3(0, 4, 0);
        }
        void Start()
        {
            //weapon = GetComponent<Weapon>();//无效

            
        }
        private void Update()
        {
            timer += Time.deltaTime;
            if (timer>5)
            {
                EnemyBase normalenemy1 = EnemySimpleFactory.CreateEnemy("NormalEnemy");
                Instantiate(NormalEnemy, new Vector3(-4, 4, 0), Quaternion.identity);
                timer = 0;
            }
            

        }

    }
    public abstract class EnemyBase : MonoBehaviour
    {
        public abstract void Move();
        public abstract void FireStart();

    }
    
    public class EnemySimpleFactory
    {
        public static EnemyBase CreateEnemy(string type)
        {
            EnemyBase enemybase = null;
            if (type == "NormalEnemy")
            {
                enemybase = new NormalEnemy();
            }
            if (type=="Boss")
            {
                enemybase = new EnemyBoss();
            }
            return enemybase;
        }

    }
    //public class EnemyBoss : EnemyBase
    //{
    //    private Vector3 direction = Vector3.left;
    //    private Director director;
    //    private float enemyspeed = 3;
    //    public void Update()
    //    {
    //        FireStart();
    //        Move();
    //    }
    //    public override void FireStart()
    //    {
    //        director.weapon.FireStart();
    //        print("fire");
    //    }

    //    public override void Move()
    //    {
    //        print("movechange");
    //        transform.position += direction * enemyspeed * Time.deltaTime;
    //        if (transform.position.x - ScreenXY.MinX < 0.3 || (transform.position.x > 0 && transform.position.x - ScreenXY.MaxX > -0.3))
    //        {
    //            direction *= -1;
    //        }
    //    }
    //}


    //public class NormalEnemy : EnemyBase
    //{
    //    private Vector3 direction = Vector3.left;
    //    private Director director;
    //    public void Update()
    //    {
    //        FireStart();
    //        Move();
    //    }
    //    public override void FireStart()
    //    {
    //        director.weapon.FireStart();

    //    }

    //    public override void Move()
    //    {
    //        transform.position += new Vector3(0, 1, 0) * 3 * Time.deltaTime;
    //    }
    //}
}