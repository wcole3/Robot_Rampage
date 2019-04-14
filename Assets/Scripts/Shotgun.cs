using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    //child class of Gun for pistol
	
	// Update is called once per frame
	override protected void Update () {
        //do whatever a gun would do
        base.Update();
        //do things only a pistol would do
        if(Input.GetMouseButtonDown(0) && (fireRate < Time.time - lastFireTime))
        {
            lastFireTime = Time.time;
            Fire();
        }
	}
}
