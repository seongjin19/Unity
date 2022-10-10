using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool start = false;

    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 0;
    }
    // Update is called once per frame
    void Update()
    {
        StartChange();
        if(start == true)
        {
            Time.timeScale = 1;
        }
    }
    public void StartChange()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            start = true;
        }
    }

}
