using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
     
    public SceneChanger changeScene;
    public static LoadGame _LoadGame;

    public bool loadPartida = false;
    public string level;
    public float PositionX;
    public float PositionY;
    
    void Start()
    {
         
       
       
       
    }
    
    public void LoaadGame()
    {
        loadPartida = true;
        changeScene.ChangeSceneTo(GameStatus._GameStatus.nameScene);
        
        
        
        // Debug.Log(GameStatus._GameStatus.tacos);
        // Debug.Log(GameStatus._GameStatus.collectablesRaw);
        // Debug.Log(GameStatus._GameStatus.nameScene);
        // Debug.Log(GameStatus._GameStatus.PositionX);
        // Debug.Log(GameStatus._GameStatus.PositionY);
        
        
        
        
        
    }
    
}
