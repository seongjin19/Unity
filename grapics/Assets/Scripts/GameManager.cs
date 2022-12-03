using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public float GameTime = 300;
    public Text GameTimeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameTime <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
        GameTime -= Time.deltaTime;
            GameTimeText.text = "Time: " + (int)GameTime;
        }
    }
}
