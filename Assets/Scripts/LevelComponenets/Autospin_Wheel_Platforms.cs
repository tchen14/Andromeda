﻿using UnityEngine;
using System.Collections;

public enum SpinType
{
   clock,
   counter

}
//this is the wheel platform holder
public class Autospin_Wheel_Platforms : MonoBehaviour
{
    public SpinType WheelBehavior;

    public Transform wheel;
    public Transform[] platforms;
    public Transform[] platformPoints;
    public float rotationSpeed;
    public float JumpSpeedAdded;
    public float WheelBreakpoint;
    public float deceleration;
    public Autospin_Wheel_Platform[] platformComp;
    public float maxSpeed = 0.8f;
    Quaternion StartingRot;
    // Use this for initialization
    void Start()
    {
        LevelReset.myLevelElements.Add(this);

        StartingRot = wheel.rotation;

      
       if (WheelBehavior == SpinType.clock)
        {
            InvokeRepeating("RotateWheel", 0.01f, 0.01f);
            JumpSpeedAdded = 0.0f;
            deceleration = 1;
            rotationSpeed = -0.8f;
        } else if (WheelBehavior == SpinType.counter)
            {
            InvokeRepeating("RotateWheel", 0.01f, 0.01f);
            JumpSpeedAdded = 0.0f;
            deceleration = 1;
            rotationSpeed = 0.8f;
        }

        for (int plat = 0; plat < platforms.Length; plat++)
        {
            //Debug.Log (plat);
            if (platforms[plat].GetComponent<Autospin_Wheel_Platform>() == null)
            {
                platforms[plat].gameObject.AddComponent<Autospin_Wheel_Platform>();
            }
            platformComp[plat] = platforms[plat].GetComponent<Autospin_Wheel_Platform>();

        }

        //
    }

    public void Reset()
    {
        wheel.rotation = StartingRot;
        rotationSpeed = 0;
    }


    void RotateWheel()
    {
        //platforms [plat].position = platformPoints [plat].position;
        wheel.Rotate(Vector3.up * rotationSpeed);
        ChangePlatType();

        if (rotationSpeed > 0)
        {
            rotationSpeed *= deceleration;
        }
        if (rotationSpeed < 0)
        {
            rotationSpeed *= deceleration;
        }

        if (Mathf.Abs(rotationSpeed) < 0.011)
        {
            rotationSpeed = 0;
        }

        if (Mathf.Abs(rotationSpeed) > maxSpeed)
        {
            if (rotationSpeed < 0)
            {
                rotationSpeed = (maxSpeed * -1);
            }
            else
            {
                rotationSpeed = maxSpeed;
            }
        }

    }

    void ChangePlatType()
    {
        for (int plat = 0; plat < platforms.Length; plat++)
        {
            platforms[plat].position = platformPoints[plat].position;
        }

    }


}
