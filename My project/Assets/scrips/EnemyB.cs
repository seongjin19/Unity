using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyB : Enemy
{
    public GameObject gameManagerB;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {

        HP = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            gameManagerB.GetComponent<GameManager>().is_clear -= 1;
            Destroy(gameObject);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("BALL"))
        {
            HP -= ball.GetComponent<BallController>().DMG;
        }
    }
}
