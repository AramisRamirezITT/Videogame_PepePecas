using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collectable : MonoBehaviour
{
    public static int cornCollectable = 0;
    public ParticleSystem collectaParticleSystem;
    public AudioSource collectableAudio;
    public Text CollectableText;
    
    
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "First_level")
        {
            cornCollectable = 0;
        }
        else
        {
            cornCollectable = GameStatus._GameStatus.collectablesRaw;
            // changeNumberOfCollectables();
        }
        collectableAudio = GetComponentInParent<AudioSource>();
        CollectableText = GameObject.Find("CollectableContador (number)").GetComponent<Text>();
        collectaParticleSystem = GameObject.Find("ParticlesCollectable").GetComponent<ParticleSystem>();

        
        NotificationCenter.DefaultCenter().AddObserver(this,"IncrementCollectable");
        NotificationCenter.DefaultCenter().AddObserver(this,"Dead");
        
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Player")
        {
            collectaParticleSystem.transform.position = transform.position; // las particulas se colocan en donde estan los elotes
            collectaParticleSystem.Play();
            collectableAudio.Play();
            gameObject.SetActive(false);
            cornCollectable++;
            NotificationCenter.DefaultCenter().PostNotification(this,"IncrementCollectable");
            changeNumberOfCollectables();

        }
        
    }
    void IncrementCollectable(Notification notification)
    {
        GameStatus._GameStatus.collectablesRaw = cornCollectable;
        GameStatus._GameStatus.Save();
        Debug.Log("Elotes Guardados: " + GameStatus._GameStatus.collectablesRaw);
        
        if (GameStatus._GameStatus.collectablesRecord <= cornCollectable)
        {
            Debug.Log("Se ha superado el record!! " + cornCollectable + " anterior: " + GameStatus._GameStatus.collectablesRecord);
            
            GameStatus._GameStatus.collectablesRaw = cornCollectable;          
            GameStatus._GameStatus.collectablesRecord = cornCollectable;
            GameStatus._GameStatus.Save();
        }
    }

    private void changeNumberOfCollectables()
    {
        CollectableText.text = cornCollectable.ToString();
    }

    
}
