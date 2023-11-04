using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   public static LevelManager instance;

    private void Awake()
    {
        if(LevelManager.instance == null)
        {
            LevelManager.instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void gameOver()
    {
        UIManager _ui = GetComponent<UIManager>();
        if(_ui != null)
        {
            _ui.ToggleDeathPanel();
        }
    }
}
