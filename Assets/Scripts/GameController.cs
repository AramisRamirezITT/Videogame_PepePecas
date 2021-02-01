using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]

public class GameController : MonoBehaviour
{
    private bool gameRunning ;
    public Canvas pauseMen;
    
    
    // Start is called before the first frame update
    void Start()
    
    {
        pauseMen = GameObject.Find("CanvasPause").GetComponent<Canvas>();
        pauseMen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeRunnningState();
        }

    }

    public void ChangeRunnningState()
    {
        gameRunning = !gameRunning;
        
        if (gameRunning)
        {
            Debug.Log("Game Running");
            Time.timeScale = 1f;
            pauseMen = GameObject.Find("CanvasPause").GetComponent<Canvas>();
            pauseMen.enabled = false;
           
        }
        else
        {
            
            Debug.Log("Game pause");
            Time.timeScale = 0f;
            pauseMen = GameObject.Find("CanvasPause").GetComponent<Canvas>();
            pauseMen.enabled = true;
        }
    }

    public bool IsGameRunning()
    {
        return gameRunning;
    }
    
}
