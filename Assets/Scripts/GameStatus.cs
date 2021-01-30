using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class GameStatus : MonoBehaviour
{
    public static GameStatus _GameStatus;
    private string pathData;
    
    
    public int tacos;
    public int level;
    public int collectablesRaw;
    public string collectables;
    
   
    
    void Awake()
    {
        // Debug.Log(Application.persistentDataPath);
        pathData = Application.persistentDataPath + "/data.dat";
        
        if (!_GameStatus)
        {
            _GameStatus = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(_GameStatus != this)
        {
            Destroy(gameObject); 
        }
        
    }
    
    void Start()
    {
        

        Load();

    }
    
    void Update()
    {
        
        // HP vida = GetComponent<HP>();
        // tacos = vida.i;
    }
    
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(pathData);

        SaveData data = new SaveData();
        data.collectablesRaw = collectablesRaw;
        
        bf.Serialize(file, data);

        file.Close();
    }
    
    void Load()
    {
        
        
        if (File.Exists(pathData))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(pathData,FileMode.Open);

            SaveData data = (SaveData) bf.Deserialize(file);

            collectablesRaw = data.collectablesRaw;

            file.Close();
        }
        else
        {
            collectablesRaw = 0;
        }

    }
    
    [Serializable]
    class SaveData
    {
        public int collectablesRaw;
        
        
    }
    
}

