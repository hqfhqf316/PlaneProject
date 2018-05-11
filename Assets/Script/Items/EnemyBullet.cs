using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    [SerializeField]
    private float speed = 4;
    [SerializeField]
    private int damageValue = 20;
	
	void Start () {
		
	}
	
	
	void Update () {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if (transform.position.y < ScreenXY.MinY)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
        if (other.GetComponent<IHealth>() != null)
        {
            other.GetComponent<IHealth>().Damage(damageValue);
        }
    }
    
}
