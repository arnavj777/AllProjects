using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockDrop : MonoBehaviour
{
    public float timeRemaining = 2;
    bool startBool = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startBool)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                Debug.Log(timeRemaining);
            }
            Debug.Log(timeRemaining);
            if (timeRemaining < 0)
            {
                Destroy(this.gameObject);
            }

        }
    }

        public void OnCollisionEnter(Collision collision)
        {
            
                startBool = true;

            
        }
    
}
