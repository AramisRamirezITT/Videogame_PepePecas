using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveFunction : MonoBehaviour
{
    public int taquitos;
    public int  corn;
    public string level;
    public float [] position;
    
    
    void Start()
    {
         
        taquitos = GameStatus._GameStatus.tacos;
        corn = GameStatus._GameStatus.collectablesRaw;
        level = SceneManager.GetActiveScene().name;

        position = new float[2];
        position[0] = GameObject.Find("Player").transform.position.x;
        position[1] = GameObject.Find("Player").transform.position.y;
        
    }
    

    public void SaveData()
    {
        GameStatus._GameStatus.tacos = taquitos;
        GameStatus._GameStatus.collectablesRaw = corn;
         
    }
}
