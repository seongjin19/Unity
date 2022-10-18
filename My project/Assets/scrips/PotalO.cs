using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalO : MonoBehaviour
{
    
    public GameObject potal2;
    public GameObject ball;
    float random;
    public bool block;
    float timer;
    float waitTime;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        block = true;
        timer = 0.0f;
        waitTime = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(block == false)
        {
            timer += Time.deltaTime;
            if (timer > waitTime)
            {
                timer = 0;
                block = true;
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BALL"))
        {
            random = Random.Range(-1.0f ,0.0f);
            if (potal2.transform.position.x < 0 && block == true)
            {
                block = false;
                pos = new Vector3(potal2.transform.position.x + 1, potal2.transform.position.y, potal2.transform.position.z);
                collision.transform.position = pos;
                ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
                ball.GetComponent<Rigidbody>().AddForce(new Vector3(1 ,0, random).normalized* ball.GetComponent<BallController>().speed);
            }
            if (potal2.transform.position.x > 0 && block == true)
            {
                block = false;
                pos = new Vector3(potal2.transform.position.x - 1, potal2.transform.position.y, potal2.transform.position.z);
                collision.transform.position = pos;
                ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
                ball.GetComponent<Rigidbody>().AddForce(new Vector3(-1 , 0, random).normalized* ball.GetComponent<BallController>().speed);
            }
        }
    }
}
