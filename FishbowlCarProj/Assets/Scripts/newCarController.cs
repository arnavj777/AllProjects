using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class newCarController : MonoBehaviour
{
    /*public enum ControlMode
    {
        Keyboard,
        Buttons,
        controller
    };

    public enum Axel
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        //public GameObject wheelEffectObj;
        //public ParticleSystem smokeParticle;
        public Axel axel;
    }

    public ControlMode control;

    public float maxAcceleration = 30.0f;
    public float brakeAcceleration = 50.0f;

    public float turnSensitivity = 1.0f;
    public float maxSteerAngle = 30.0f;

    public Vector3 _centerOfMass;

    public List<Wheel> wheels;

    float moveInput;
    float steerInput;

    private Rigidbody carRb;

   
    

    void Start()
    {

        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = _centerOfMass;


    }

    void Update()
    {

        GetInputs();
        AnimateWheels();
        //WheelEffects();
    }

    void LateUpdate()
    {
        
        Move();
        Steer();
        Brake();
    }

    public void MoveInput(float input)
    {
        moveInput = input;
    }

    public void SteerInput(float input)
    {
        steerInput = input;
    }

    void GetInputs()
    {
        for(int i = 0; i < Gamepad.all.Count; i++)
        {
            Debug.Log(Gamepad.all[i].name);
        }
        if (control == ControlMode.Keyboard)
        {
            moveInput = Input.GetAxis("Vertical");
            steerInput = Input.GetAxis("Horizontal");
        }
        if(control == ControlMode.controller)
        {
            if (Gamepad.all[0].rightTrigger.isPressed)
            {
                moveInput = Gamepad.all[0].rightTrigger.value;
                Debug.Log(moveInput);
                
            }
            else if(Gamepad.all[0].leftTrigger.isPressed)
            {
                moveInput = -Gamepad.all[0].leftTrigger.value;
                

            }
            else
            {
                moveInput = 0;
            }

            steerInput = Gamepad.all[0].leftStick.value.x;
        }
    }

    void Move()
    {
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = moveInput * 600 * maxAcceleration * Time.deltaTime;
        }
    }

    void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }

    void Brake()
    {
        if (Input.GetKey(KeyCode.JoystickButton2) || moveInput == 0)
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 300 * brakeAcceleration * Time.deltaTime;
            }


        }
        else
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
            }


        }
    }

    void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lava"))
        {
            playerDied();
            gameObject.SetActive(false);
        }
    }
    private void playerDied()
    {
        LevelManager.instance.gameOver();
    }
    /*
        void WheelEffects()
        {
            foreach (var wheel in wheels)
            {
                //var dirtParticleMainSettings = wheel.smokeParticle.main;

                if (Input.GetKey(KeyCode.Space) && wheel.axel == Axel.Rear && wheel.wheelCollider.isGrounded == true && carRb.velocity.magnitude >= 10.0f)
                {
                    wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = true;
                    wheel.smokeParticle.Emit(1);
                }
                else
                {
                    wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = false;
                }
            }
        }
    */

}