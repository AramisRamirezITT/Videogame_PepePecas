using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    int hp = 3;
    public Image[] hearts;
    bool hasCooldown = false;

    public SceneChanger changeScene;

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

    void SubstractHealth()
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

    void EmptyHearts()
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
