using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyR : Enemy
{
    public GameObject gameManagerR;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
        HP = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            gameManagerR.GetComponent<GameManager>().is_clear -= 1;
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
