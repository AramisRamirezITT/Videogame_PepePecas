using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pepe : MonoBehaviour
{
    public int tacos;
    public int level;
    public Text collectablesRaw;
    public string collectables;

    void Start()
    {
        collectablesRaw = GameObject.Find("CollectableContador (number)").GetComponent<Text>();

    }
    void Update()
    {
        collectables = collectablesRaw.text;
        HP vida = GetComponent<HP>();
        tacos = vida.i;
        
        // Debug.Log("game status "+ tacos);
        // Debug.Log("KKK "+ collectables);
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
        
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        tacos = data.tacos;

        Vector2 position;
        position.x = data.position[0];
        position.y = data.position[1];

        transform.position = position;

    }
    
}
