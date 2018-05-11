using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : EnemyBase
{
    
    [SerializeField]
    private float enemyspeed = 3;
    [SerializeField]
    private float repeatRate = 0.3f;
    [SerializeField]
    private float hardrepeatRate = 5f;
    private void Start()
    {
        InvokeRepeating("Attack", 0f, repeatRate);
        InvokeRepeating("HardAttack", 5f, hardrepeatRate);
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
    private void HardAttack()
    {
        Instantiate(bulletPrefab, this.transform.position + Vector3.left*2, Quaternion.identity);
        Instantiate(bulletPrefab, this.transform.position + Vector3.left, Quaternion.identity);
        Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
        Instantiate(bulletPrefab, this.transform.position + Vector3.right, Quaternion.identity);
        Instantiate(bulletPrefab, this.transform.position + Vector3.right*2, Quaternion.identity);
    }
}

