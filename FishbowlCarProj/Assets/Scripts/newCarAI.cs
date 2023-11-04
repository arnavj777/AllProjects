using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;

public class newCarAI : MonoBehaviour
{
    bool isDead = false;
    Vector3 shortestDistance;
    private Vector3 targetPosition;
    public TileManager tileManager;
    Vector3 dirToMovePosition;



    private bool isBreaking;


    

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
        isBreaking = false;


    }

    void Update()
    {
        
        AnimateWheels();
        //WheelEffects();
    }

    void LateUpdate()
    {
        Brake();
        Move();
        Steer();
        
    }

    public void MoveInput(float input)
    {
       
    }

    public void SteerInput(float input)
    {
        
    }

    

    void Move()
    {
        SetTargetPosition(shortestDistance);

        float reachedTargetDistance = 5f;

        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
        dirToMovePosition = (targetPosition - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, dirToMovePosition);


        if (distanceToTarget > reachedTargetDistance)
        {
            isBreaking = false;
            if (dot > 0)
            {
                moveInput = 1f;
            }
            else
            {
                moveInput = -1f;
            }


            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.motorTorque = moveInput * 600 * maxAcceleration * Time.deltaTime;
            }



        }
        else
        {
            isBreaking = true;
        }
        
    }

    void Steer()
    {
        var _steerAngle = 0f;

        float angleToDir = Vector3.SignedAngle(transform.forward, dirToMovePosition, Vector3.up);
        Debug.Log(angleToDir);
         if (angleToDir > -30 && angleToDir <= 30)
            {
             _steerAngle = angleToDir;
            }
         
         if(angleToDir > 30)
        {
            _steerAngle = 30;

        }
        if (angleToDir < -30)
        {
            steerInput = -30;

        }

        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                //var _steerAngle = steerInput * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 1f);
            }
        }

    }

    void Brake()
    {
        if (isBreaking)
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
            Destroy(this.gameObject);
            isDead = true;
            Debug.Log("Dead");
        }
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
    public void SetTargetPosition(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
    public Vector3 getShortestDistance()
    {
        Material deleteColor = tileManager.getColorRemoved();
        shortestDistance = tileManager.tiles[0].transform.position;

        for (int x = 0; x < tileManager.tiles.Length; x++)
        {
            if (tileManager.tileColorDict[tileManager.tiles[x]] == deleteColor)
            {
                if (Vector3.Distance(tileManager.tiles[x].transform.position, transform.position) < Vector3.Distance(shortestDistance, transform.position))
                {
                    shortestDistance = tileManager.tiles[x].transform.position;

                }

            }
        }
        return shortestDistance;
    }
}