using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed;
    private bool r3Toggle = false;

    public Vector2 turn;
    
    
    void LateUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }
   

    private void HandleTranslation()
    {
        var targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);

    }


    private void HandleRotation()
    {
        R3Toggle();
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        if (r3Toggle)
        { 
        
       
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        }
        if (!r3Toggle)
        {
           
        }
    }
    public void R3Toggle()
    {
        if (Gamepad.all[0].rightStickButton.isPressed)
        {
            r3Toggle = true;
        }
         
    }
    
}

