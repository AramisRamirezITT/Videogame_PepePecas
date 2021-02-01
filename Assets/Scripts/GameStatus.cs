using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;


public class GameStatus : MonoBehaviour
{
    public static GameStatus _GameStatus;
    
    private string pathData;
    public int tacos;
    public int collectablesRaw;
    public int collectablesRecord ;
    public Text TacosLive;
    public Text score;
    public Text collectablesRawText;
   
    
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
        if (SceneManager.GetActiveScene().name == "Next_Level")
        {
            TacosLive = GameObject.Find("HearthContador(number)").GetComponent<Text>();
            TacosLive.text = tacos.ToString();
        }
        else if (SceneManager.GetActiveScene().name == "LoseScene" || SceneManager.GetActiveScene().name == "WinScene")
        {
            score = GameObject.Find("CollectableNumber").GetComponent<Text>();
            collectablesRawText = GameObject.Find("BestScore").GetComponent<Text>();
            
            score.text = collectablesRaw.ToString();
            collectablesRawText.text = collectablesRecord.ToString();
            // Debug.Log("Estyo en lose");
        }
        
        
        
        
        
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
            tacos = data.tacos;
            collectablesRecord = data.collectablesRecord;
            
            file.Close();
        }
        else
        {
            collectablesRaw = 0;
            tacos = 3;
        }

    }
    
    [Serializable]
    class SaveData
    {
        public int collectablesRaw;
        public int tacos;
        public int collectablesRecord;


    }

}