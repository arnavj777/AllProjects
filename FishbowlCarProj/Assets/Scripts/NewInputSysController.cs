using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NewInputSysController : MonoBehaviour
{

    PlayerControls controls;
    



   
    private void OnEnable()
    {
        
        controls.Controller.Enable();
    }
    private void Awake()
    {
        this.controls = new PlayerControls();

        this.controls.Controller.Brake.performed += ctx => Brake();
        this.controls.Controller.Brake.canceled += ctx => notBrake();

        this.controls.Controller.Forwards.performed += ctx => moveInput = ctx.ReadValue<float>();
        this.controls.Controller.Forwards.canceled += ctx => moveInput = 0f;

        this.controls.Controller.Backwards.performed += ctx => moveInput = -ctx.ReadValue<float>();
        this.controls.Controller.Backwards.canceled += ctx => moveInput = 0f;

        this.controls.Controller.Turn.performed += ctx => steerInput = ctx.ReadValue<float>();

       
        
        this.controls.Controller.Restart.performed += ctx => ReloadCurrentScene();
        

        

    }
    public void ReloadCurrentScene()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    
    }


    

    void OnDisable()
    {
        controls.Controller.Disable();
    }










    public enum ControlMode
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
        //Debug.Log(steerInput);
        
        AnimateWheels();
        


        //WheelEffects();
    }

    void LateUpdate()
    {
        Move();
        Steer();

    }

    

   

    void Move()
    {
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = moveInput * 600 * maxAcceleration * Time.deltaTime;
           /* if (!Gamepad.all[0].rightTrigger.isPressed && !Gamepad.all[0].leftTrigger.isPressed)
            {
                Brake();    
            }*/
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
       
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 300 * brakeAcceleration * Time.deltaTime;
            }
            Debug.Log("brake");
          
    }

       /*
        else
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
            }


        }*/
    
    void notBrake()
    {
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.brakeTorque = 0f;
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


}
