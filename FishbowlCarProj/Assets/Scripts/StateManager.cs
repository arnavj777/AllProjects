using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    public bool isDead = false;
    public void Update()
    {
       
            if (Gamepad.all[0].buttonSouth.isPressed)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        
    }
    public void ReloadCurrentScene()
    {
        if (Gamepad.all[0].buttonSouth.isPressed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ChangeSceneByName(string Name)
    {
        if (Name != null)
        {
            SceneManager.LoadScene(Name);
        }
    }
}
