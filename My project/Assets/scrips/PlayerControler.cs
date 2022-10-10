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
            if(moveL == false)
            {
                moveL = true;
            }
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        //if (Input.GetKey(KeyCode.LeftArrow) == true)
        //{
        //    playerRd.velocity = Vector3.left * speed;
        //}
        //else if (Input.GetKey(KeyCode.RightArrow) == true)
        //{
        //    playerRd.velocity = Vector3.right * speed;
        //}
        //float xMove = Input.GetAxis("Horizontal");

        //Vector3 getVel = new Vector3(xMove, 0, 0) * speed;
        //playerRd.velocity = getVel;

    }

    //public Vector3 ClampPosition(Vector3 position)
    //{
    //    return new Vector3(Mathf.Clamp(position.x, -mLimit.x, mLimit.x), 0, -9.45f); // 좌우로 움직이는 이동범위 설정
    //}
    private void OnCollisionEnter(Collision collision)
    {
        
        Debug.Log("왜안돼씨발");
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
