using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{

    public Material Black;
    public Material Blue;
    public Material Brown;
    public Material Green;
    public Material Orange;
    public Material Purple;
    public Material Red;
    public Material colorToDelete;
    public Material removeColor;

    public GameObject[] tiles;
    public Dictionary<GameObject, Material> tileColorDict = new Dictionary<GameObject, Material>();
    public List<Material> tileColor = new List<Material>();
    public List<Material> Colors = new List<Material>();

    int randomIndex;
    private float time;
    private float timetwo = 5;
    private float timethree = 5;
    private float timeLeft;

   
    public TextMeshProUGUI startText;
    public TextMeshProUGUI colorDisplayText;


    private int BlackTiles = 7;
    private int BlueTiles = 7;
    private int BrownTiles = 7;
    private int GreenTiles = 7;
    private int OrangeTiles = 7;
    private int PurpleTiles = 7;
    private int RedTiles = 7;
    private int Num = 0;


    
    public bool getColor;
    public bool resetTilesBool;

    private bool runTimer;
    public bool started;
    public bool runTimerTwo = false;
    public bool runTimerThree = false;
   


    void Start()
    {
        resetTilesBool = false;
        initializeTiles();
        StartTimer();
        UpdateTime();
        started = true;
        getColor = true;


    }

    // Update is called once per frame
    void Update()
    {
       
        if (getColor)
        {
            Material removeColor = getRandomColor();
            colorDisplayText.text = "Color: " + removeColor.name;
            getColor = false;
        }
        if (started)
        {

            time -= Time.deltaTime;
            UpdateTime();
            if (time <= 0)
            {
                startText.text = "Time: 0:00";
                removeTiles(removeColor);
                started = false;
                runTimerTwo = true;
                timetwo = 5;
            }
        }

        if (runTimerTwo)
        {

            timetwo -= Time.deltaTime;
            UpdateTime(timetwo);
            if (timetwo <= 0)
            {
                startText.text = "Time: 0:00";
                

                runTimerTwo = false;
                resetTilesBool = true;
                runTimer = true;
                getColor = true;
                started = true;
                time = 10;
            }
        }
        resetTiles();




        



    }
    




    public Material AssignColor()
    {
       int random = UnityEngine.Random.Range(0, tileColor.Count);
        
       Material color = tileColor[random];
       if(color == Black)
        {
            BlackTiles--;
        }
       if(color == Blue)
        {
                BlueTiles--;
        }
       if(color == Brown)
        {
                 BrownTiles--;
        }
       if(color == Green)
        {
                  GreenTiles--;
        }
       if(color == Orange)
        {
                     OrangeTiles--;
        }
       if(color == Purple)
        {
                         PurpleTiles--;
        }
       if(color == Red)
        {
                              RedTiles--;
        }
       if (BlackTiles == 0)
        {
            tileColor.Remove(Black);
        }
       if (BlueTiles == 0)
        {
                tileColor.Remove(Blue);
          }
       if (BrownTiles == 0)
        {
                 tileColor.Remove(Brown);
        }
       if (GreenTiles == 0)
        {
                    tileColor.Remove(Green);
          }
       if (OrangeTiles == 0)
        {
                     tileColor.Remove(Orange);
        }
       if (PurpleTiles == 0)
        {
                             tileColor.Remove(Purple);
          }
       if (RedTiles == 0)
        {
                               tileColor.Remove(Red);
        }


        return color ;
    }
    
    public void initializeTiles()
    {
        tileColor.Add(Black);
        tileColor.Add(Blue);
        tileColor.Add(Brown);
        tileColor.Add(Green);
        tileColor.Add(Orange);
        tileColor.Add(Purple);
        tileColor.Add(Red);

        Colors = new List<Material>() { Black, Blue, Brown,Green,Orange,Purple,Red };

        tiles = GameObject.FindGameObjectsWithTag("Tile");


        for (int i = 0; i < tiles.Length; i++)
        {
            tileColorDict.Add(tiles[i], AssignColor());
            tiles[i].GetComponent<Renderer>().material = tileColorDict[tiles[i]];
        }
    }

    public void removeTiles( Material toDelete)
    {
        
            for (int i = 0; i < tiles.Length; i++)
            {
                if (tileColorDict[tiles[i]] != colorToDelete)
                {
               
                    tiles[i].SetActive(false);

                }
            }
                    
                    
                
            
        
    }









    public void StartTimer()
    {
        time = 10;
        started = true;
    }

    public void UpdateTime()
    {
        string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = Mathf.Floor(time % 60).ToString("00");
        startText.text = string.Format("Time: {0}:{1}", minutes, seconds);
    }

    public void UpdateTime(float time)
    {
        string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = Mathf.Floor(time % 60).ToString("00");
        startText.text = string.Format("Time: {0}:{1}", minutes, seconds);
    }














    public Material getRandomColor()
    {
        System.Random random = new System.Random();
        int x = random.Next(0, Colors.Count - 1);
        colorToDelete = Colors[x];
        return Colors[x];
    }


    public void resetTiles()
    {
        if (resetTilesBool)
        {

            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].SetActive(true);
            }
        }
        resetTilesBool = false;
    }
    
    public Material getColorRemoved()
    {
        return colorToDelete;
    }




   
}
