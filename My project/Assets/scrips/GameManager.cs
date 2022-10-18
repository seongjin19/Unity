using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int is_clear;
    public GameObject Timer;
    public GameObject Ball;
    public bool firstStart = false;
    public bool start = false;
    public GameObject gameoverPanel;
    public GameObject gameclearPanel;
    // Start is called before the first frame update
    private void Start()
    {
        is_clear = 33;
        Time.timeScale = 0;
        gameoverPanel.SetActive(false);
        gameclearPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        GameStart();
        GameOver();
        GameClear();
    }
    public void StartChange()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            start = true;
        }
    }

    public void GameOver()
    {
        if (Timer.GetComponent<UIManager>().LimitTime < 0 || Ball.GetComponent<BallController>().EndLine == true)
        {
            Time.timeScale = 0.0f;
            start = false;
            if (gameoverPanel.activeSelf == false)
            {
                gameoverPanel.SetActive(true);
            }
            Ball.SetActive(false);
        }
        ReStart();
        
    }

    public void ReStart()
    {

        if (start == false)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
            
        }
    }
    public void GameStart()
    {
        if(Input.GetKeyDown(KeyCode.Space) && firstStart == false)
        {
            StartChange();  //start = true
            firstStart = true;
            Time.timeScale = 1;
        }
    }
    public void GameClear()
    {
        if(is_clear == 0)
        {
            Time.timeScale = 0;
            start = false;
            if(gameclearPanel.activeSelf == false)
            {
                gameclearPanel.SetActive(true);
            }
            Ball.SetActive(false);
        }
        ReStart();
    }
}
