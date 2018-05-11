using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InputManger :ContinuousSingleTon<InputManger>{
    
    public event Action OnSpaceDown;
    public event Action OnSpace;
    public event Action<Vector3> OnMovement;
    public event Action OnRevive;
    public event Action OnEsc;
    public event Action OnSetting;
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
        else if (Input.GetKeyDown(KeyCode.J))
        {
            
                OnRevive.Invoke();
                Debug.Log("revive2");
            
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Esc();
        }
        if (OnMovement!=null)
        {
            OnMovement.Invoke(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0));
        }
    

    }
    public void Esc()
    {
        //Pause.Esc();
        OnEsc.Invoke();
    }
    public void Setting()
    {
        // Pause.Setting();
        OnSetting.Invoke();
    }
}
