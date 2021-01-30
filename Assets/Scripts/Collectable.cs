using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public static int cornCollectable = 0;
    public ParticleSystem collectaParticleSystem;
    public AudioSource collectableAudio;
    public Text CollectableText;
    // private Notification notification;
    
    void Start()
    {
        cornCollectable = 0;
        collectaParticleSystem = GameObject.Find("ParticlesCollectable").GetComponent<ParticleSystem>();
        collectableAudio = GetComponentInParent<AudioSource>();
        CollectableText = GameObject.Find("CollectableContador (number)").GetComponent<Text>();
        
        NotificationCenter.DefaultCenter().AddObserver(this,"IncrementCollectable");
        NotificationCenter.DefaultCenter().AddObserver(this,"VerVidas");
        
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
            CollectableText.text = cornCollectable.ToString();
            
        }
        
    }

    
}
