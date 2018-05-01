using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlane : MonoBehaviour {

    [SerializeField]
    private float speed=5;
    private Vector3 direction;
    private float MaxX;
    private float MinX;
    private float MaxY;
    private float MinY;
	// Use this for initialization
	void Start () {
        MaxX = ScreenXY.MaxX;
        MaxY = ScreenXY.MaxY;
        MinX = ScreenXY.MinX;
        MinY = ScreenXY.MinY;
	}
	
	// Update is called once per frame
	void Update () {
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Move(direction);
        ClamFrame();
    }

    private void Move(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void ClamFrame()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX,MaxX),
            Mathf.Clamp(transform.position.y, MinY, MaxY),
            transform.position.z);
    }
}
