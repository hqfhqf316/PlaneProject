using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField]
    private float speed = 4;
    [SerializeField]
    private int damageValue = 50;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.up * speed * Time.deltaTime;
        if (transform.position.y>ScreenXY.MaxY)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<IHealth>() != null)
        {
            other.GetComponent<IHealth>().Damage(damageValue);
        }
    }
    
}
