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

        public Weapon weapon;
        static void Main()
        {
            EnemyBase normalenemy1 = EnemySimpleFactory.CreateEnemy("NormalEnemy");

            EnemyBase boss = EnemySimpleFactory.CreateEnemy("Boss");
        }
        void Start()
        {
            weapon = GetComponent<Weapon>();

        }

    }
    public abstract class EnemyBase : MonoBehaviour
    {
        public abstract void Move();
        public abstract void FireStart();

    }
    public class EnemyBoss : EnemyBase
    {
        private Vector3 direction = Vector3.left;
        private Director director;
        public override void FireStart()
        {
            director.weapon.FireStart();
           
        }

        public override void Move()
        {
            if (transform.position.x - ScreenXY.MinX < 0.3 || (transform.position.x > 0 && transform.position.x - ScreenXY.MaxX > -0.3))
            {
                direction *= -1;
            }
        }
    }
    public class NormalEnemy : EnemyBase
    {
        private Vector3 direction = Vector3.left;
        private Director director;
        public override void FireStart()
        {
            director.weapon.FireStart();

        }

        public override void Move()
        {
            transform.position += new Vector3(0, 1, 0) * 3 * Time.deltaTime;
        }
    }
    public class EnemySimpleFactory
    {
        public static EnemyBase CreateEnemy(string type)
        {
            EnemyBase enemybase = null;
            if (type=="NormalEnemy")
            {
                enemybase = new NormalEnemy();
            }
            else if (type=="Boss")
            {
                enemybase = new EnemyBoss();
            }
            return enemybase;
        }

    }
}