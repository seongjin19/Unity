using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : GameManager
{
    public float LimitTime;
    public TMP_Text text_Timer;
    
    // Start is called before the first frame update
    void Start()
    {
        LimitTime = 180.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && start == false)
        {
            StartChange();
        }
       
       
        LimitTime -= Time.deltaTime;
        
        text_Timer.text = "time : " + Mathf.Round(LimitTime);
        
    }


}
