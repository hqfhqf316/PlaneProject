using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InputManger :SingleTon<InputManger>{
    [SerializeField]
   // private MainPlane mainPlane;
    public event Action OnSpaceDown;
    public event Action OnSpace;
    public event Action<Vector3> OnMovement;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (OnSpaceDown!=null)
           // mainPlane.FireOnce();
            OnSpaceDown.Invoke();
        }
       else if (Input.GetKey(KeyCode.Space))
        {
            // mainPlane.FireStart();
            if (OnSpace!=null)
            {
            OnSpace.Invoke();
            }
        }
        if (OnMovement!=null)
        {
            OnMovement.Invoke(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0));
        }
    }
}
