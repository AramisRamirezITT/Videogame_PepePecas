using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    // ***************************
    // public static HP _Hp;
    public int hp = 3;
    private int i;
    public Image[] hearts;
    bool hasCooldown = false;
    public SceneChanger changeScene;
    public Rigidbody2D pepe;
    private Notification notification;
    
    // public float minHeightForDeath ;
    private float x = 5.7f;
    private float y = 2.2f;
    // private float z = 10.625f;
    // ****************************
    public void VerVidas (Notification notification)
    {
       
        if (Collectable.cornCollectable > 0)
        {
            Debug.Log("Puntuacion Actual: " + Collectable.cornCollectable + "Puntuacion Anterior" +  GameStatus._GameStatus.collectablesRaw);
            Debug.Log("Vida actual: " + hp + "Vida anterior: " + GameStatus._GameStatus.tacos);
            GameStatus._GameStatus.collectablesRaw = Collectable.cornCollectable;
            GameStatus._GameStatus.tacos = hp;
            GameStatus._GameStatus.Save();
        }
    }
    
    
    
    void start()
    {
       
        NotificationCenter.DefaultCenter().AddObserver(this,"IncrementCollectable");
        NotificationCenter.DefaultCenter().AddObserver(this,"VerVidas");

    }

    void Update()
    {
        VerVidas( notification );
        
        if (pepe.transform.position.y <= -30f )
        {
            SubstractHealth();
            transform.position = new Vector2(x,y);
        }
        
        
    }
    
    // ****************************
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (GetComponent<PlayerMove>().isGrounded)
            {
                SubstractHealth();
            }
        }
    }

    public void SubstractHealth()
    {
        if (!hasCooldown)
        {
            if(hp > 0)
            {
                hp--;
                NotificationCenter.DefaultCenter().PostNotification(this,"VerVidas");
                hasCooldown = true;
                StartCoroutine(Cooldown());
            }

            if(hp <= 0)
            {
                changeScene.ChangeSceneTo("LoseScene");
            }
            EmptyHearts();
        }
    }

    public void EmptyHearts()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if (hp - 1 < i)
                hearts[i].gameObject.SetActive(false);
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(.5f);
        hasCooldown = false;

        StopCoroutine(Cooldown());
    }
    
   
    
}
