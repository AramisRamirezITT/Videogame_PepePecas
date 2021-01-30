using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    public static GameStatus _GameStatus;
    // public int tacos;
    // public int level;
    // public Text collectablesRaw;
    // public string collectables;
   
    
    void Awake()
    {
        // if (!_GameStatus)
        // {
        //     _GameStatus = this;
            DontDestroyOnLoad(gameObject);
        // }
        // else if(_GameStatus != this)
        // {
        //     Destroy(gameObject); 
        // }
        
    }
    // void Start()
    // {
    //     collectablesRaw = GameObject.Find("CollectableContador (number)").GetComponent<Text>();
    //
    // }
    //
    // void Update()
    // {
    //     collectables = collectablesRaw.text;
    //     HP vida = GetComponent<HP>();
    //     tacos = vida.i;
    // }
    
}

