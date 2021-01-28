using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public static int cornCollectable = 0;
    public ParticleSystem collectaParticleSystem;
    public AudioSource collectableAudio;
    public Text CollectableText;
    
    void Start()
    {
        cornCollectable = 0;
        collectaParticleSystem = GameObject.Find("ParticlesCollectable").GetComponent<ParticleSystem>();
        collectableAudio = GetComponentInParent<AudioSource>();
        CollectableText = GameObject.Find("CollectableContador (number)").GetComponent<Text>();
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
            CollectableText.text = cornCollectable.ToString();
        }
        
    }
}
