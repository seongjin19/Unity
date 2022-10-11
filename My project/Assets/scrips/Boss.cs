using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public GameObject gameManagerS;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        HP = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            gameManagerS.GetComponent<GameManager>().is_clear -= 1;
            Debug.Log(gameManagerS.GetComponent<GameManager>().is_clear);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BALL"))
        {
            HP -= ball.GetComponent<BallController>().DMG;
        }
    }
}
