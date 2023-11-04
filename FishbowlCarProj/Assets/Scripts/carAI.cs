using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class carAI : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    Vector3 shortestDistance;

    TileManager tileManager;

    private float currentSteeringAngle;
    private float currentBreakForce;
    private bool isBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteeringAngle;



    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    [SerializeField] private Transform targetPositionTransform;

    
    [SerializeField] private bool isDead = false;


    private Vector3 targetPosition;

    GameObject y;

    private void Start()
    {
        tileManager = GameObject.Find("TileManager").GetComponent<TileManager>();
    }

    void FixedUpdate()
    {

        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    public Vector3 getShortestDistance()
    {
        Material deleteColor = tileManager.getColorRemoved();
        shortestDistance = tileManager.tiles[0].transform.position;
       
        for(int x = 0; x < tileManager.tiles.Length; x++)
        {
            if (tileManager.tileColorDict[tileManager.tiles[x]] == deleteColor)
            {
                if(Vector3.Distance(tileManager.tiles[x].transform.position, transform.position) < Vector3.Distance(shortestDistance, transform.position))
                {

                    shortestDistance = tileManager.tiles[x].transform.position;

                }

            }
        }
        return shortestDistance;
    }

    // set position methods for ai
    public void SetTargetPosition(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }




    // controll movement methods

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentBreakForce = isBreaking ? breakForce : 0f;

        if (isBreaking)
        {
            frontRightWheelCollider.brakeTorque = breakForce;
            frontLeftWheelCollider.brakeTorque = breakForce;
            rearRightWheelCollider.brakeTorque = breakForce;
            rearLeftWheelCollider.brakeTorque = breakForce;

        }
        else
        {
            frontRightWheelCollider.brakeTorque = 0f;
            frontLeftWheelCollider.brakeTorque = 0f;
            rearRightWheelCollider.brakeTorque = 0f;
            rearLeftWheelCollider.brakeTorque = 0f;
        }

    }


    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentBreakForce;
        frontLeftWheelCollider.brakeTorque = currentBreakForce;
        rearRightWheelCollider.brakeTorque = currentBreakForce;
        rearLeftWheelCollider.brakeTorque = currentBreakForce;
    }

    private void GetInput()
    {
        SetTargetPosition(getShortestDistance());
        
        float reachedTargetDistance = 5f;

        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
        Vector3 dirToMovePosition = (targetPosition - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, dirToMovePosition);


        if(distanceToTarget > reachedTargetDistance)
        {
            isBreaking = false;
            if (dot > 0)
            {
                verticalInput = 1f;
            }
            else
            {
                verticalInput = -1f;
            }

            float angleToDir = Vector3.SignedAngle(transform.forward, dirToMovePosition, Vector3.up);
            
            if (angleToDir > 30)
            {
                currentSteeringAngle = 30;
            }
            else if(angleToDir < -30)
            {
                currentSteeringAngle = -30;
            }
            else if (angleToDir >= -30 && angleToDir <= 30)
            {
                currentSteeringAngle = -30;
            }
            else
            {
                currentSteeringAngle = 0;
            }
            
        }
        else
        {
            verticalInput = 0f;
            currentSteeringAngle = 0;
            isBreaking = true;
        }
        

    

       
       
    }

    private void HandleSteering()
    {
        
        frontLeftWheelCollider.steerAngle = currentSteeringAngle;
        frontRightWheelCollider.steerAngle = currentSteeringAngle;
    }
    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);


    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;

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

    



}


