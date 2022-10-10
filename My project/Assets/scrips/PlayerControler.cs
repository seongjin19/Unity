using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    
    public float speed = 10.0f;
    private bool moveR, moveL;
    // 이동 가능한 범위
    Vector2 mLimit = new Vector2(8.0f, 0);

    // Start is called before the first frame update
    void Start()
    {
        moveR = true;
        moveL = true;
    }

    // Update is called once per frame
    void Update()
    {

        //transform.localPosition = ClampPosition(transform.localPosition);

        if (Input.GetKey(KeyCode.LeftArrow) == true && moveL == true)
        {
            if (moveR == false)
            {
                moveR = true;
            }
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.RightArrow) == true && moveR == true)
        {
            if (moveL == false)
            {
                moveL = true;
            }
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            if(transform.position.x > collision.transform.position.x)
            {
                moveL = false;
            }
            else
            {
                moveR = false;
            }
        }
    }
}