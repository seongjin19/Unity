using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public GameObject gameManager;
    public float LimitTime;
    public TMP_Text text_Timer;
    public GameObject text_start;
    
    // Start is called before the first frame update
    void Start()
    {
        LimitTime = 180.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetComponent<GameManager>().start == true)
        {
            text_start.SetActive(false);
        }


        LimitTime -= Time.deltaTime;

        text_Timer.text = "time : " + Mathf.Round(LimitTime);        
    }
}
