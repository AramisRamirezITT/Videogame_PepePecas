using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SaveFunction : MonoBehaviour
{
    
    public string level;
    public float[] position;
    public float PositionX;
    public float PositionY;
    
    void Start()
    {
         
       
        level = SceneManager.GetActiveScene().name;
        
        // position = new float[2];
        PositionX = GameObject.Find("Player").transform.position.x;
        PositionY = GameObject.Find("Player").transform.position.y;
    }
    

    public void SaveData()
    {
        
        GameStatus._GameStatus.nameScene = level;
        GameStatus._GameStatus.PositionX = PositionX;
        GameStatus._GameStatus.PositionY = PositionY;
        GameStatus._GameStatus.Save();
        
        Debug.Log(GameStatus._GameStatus.tacos);
        Debug.Log(GameStatus._GameStatus.collectablesRaw);
        Debug.Log(GameStatus._GameStatus.nameScene);
        Debug.Log(GameStatus._GameStatus.PositionX);
        Debug.Log(GameStatus._GameStatus.PositionY);
        
    }
}
