using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    // ***************************
    public static HP _GameStatus;
    public int hp = 3;
    public int i;
    public Image[] hearts;
    bool hasCooldown = false;
    public SceneChanger changeScene;
    public Rigidbody2D pepe;
    
    // public float minHeightForDeath ;
    private float x = 5.7f;
    private float y = 2.2f;
    // private float z = 10.625f;
    // ****************************
    void Awake()
    {
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
    
    void start()
    {
        
    }

    void Update()
    {
        if (pepe.transform.position.y <= -30f )
        {
            // Debug.Log("muertoooooo");
            SubstractHealth();
            transform.position = new Vector2(x,y);
        }

        i = hp;
        // Debug.Log(i);
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
