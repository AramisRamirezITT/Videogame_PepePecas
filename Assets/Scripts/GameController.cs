using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]

public class GameController : MonoBehaviour
{
    public static GameController _GameController;
    public bool gameRunning;
    public Canvas pauseMen;
    public Button ButtonResume;
    
    
    // Start is called before the first frame update
    void Start()

    {
        gameRunning = true;
        pauseMen = GameObject.Find("CanvasPause").GetComponent<Canvas>();
        pauseMen.enabled = false;
        // ButtonResume = GameObject.FindGameObjectWithTag("Resume").GetComponent<Button>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameRunning = false;
        }

        if (gameRunning == false)
        {
            Debug.Log("Game pause");
            Time.timeScale = 0f;
            pauseMen = GameObject.Find("CanvasPause").GetComponent<Canvas>();
            pauseMen.enabled = true;
            
        }
        else
        {
            Debug.Log("Game running");
            Time.timeScale = 1f;
            pauseMen = GameObject.Find("CanvasPause").GetComponent<Canvas>();
            pauseMen.enabled = false;
            // ChangeRunnningState();
        }
       

    }
    
    

    public bool IsGameRunning()
    {
        return gameRunning;
    }
    
}
