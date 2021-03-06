﻿using UnityEngine;
using System.Collections;

public enum platType{
	right,
	left, 
	none

}


public class WheelPlatform : MonoBehaviour {

	public WheelPlatforms myWheel;
	public platType myType;

	float breakPoint;
	float addspeed;
	// Use this for initialization
	void Start () {
		myWheel = this.gameObject.transform.parent.GetComponent<WheelPlatforms> ();
		addspeed = myWheel.JumpSpeedAdded;
		breakPoint = myWheel.WheelBreakpoint;
        
	}
	
	void FixedUpdate(){
        if ((Mathf.Abs(this.gameObject.transform.localPosition.x) < breakPoint) &&
            this.gameObject.transform.localPosition.y < 0f)  {
            myType = platType.none;
            
        } else if (this.gameObject.transform.localPosition.x > breakPoint) {
			myType = platType.right;
		} else if (this.gameObject.transform.localPosition.x < (breakPoint * -1f)) {
			myType = platType.left;
		} else {
            myType = platType.left;
        }


	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Player") {
			if (myType == platType.none) {
               
                print(gameObject.transform.localPosition.z);
                print("Y:" + gameObject.transform.localPosition.y);
                return;
			}
			if (myType == platType.right) {
				
				myWheel.rotationSpeed -= addspeed;
				return;
			
			}

			if (myType == platType.left) {
				
				myWheel.rotationSpeed += addspeed;
				return;
			}





		}


	}


}
