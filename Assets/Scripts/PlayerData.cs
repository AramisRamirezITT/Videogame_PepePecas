using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerData : MonoBehaviour
{
   public int level;
   public int tacos;
   public string collectables;
   public float[] position;
   
   public PlayerData(Pepe player)
   {
      level = player.level;
      tacos = player.tacos;
      collectables = player.collectables;
      
      position = new float[2];
      position[0] = player.transform.position.x;
      position[1] = player.transform.position.y;

   }
}


