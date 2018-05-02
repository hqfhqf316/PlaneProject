using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField]
    private float speed = 4;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collision" + collision.gameObject.name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("triggle" + collision.gameObject.name);
    }
}
