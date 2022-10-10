using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : GameManager
{
    public Transform player;
    private Rigidbody ballRd;   //Rigidbody 컴포넌트 저장
    public float speed = 100.0f;
    Vector3 startPos; // 공의 출발위치 정보를 저장하는 변수
    

    // Start is called before the first frame update
    void Start()
    {
        ballRd = GetComponent<Rigidbody>();  //Rigidbody 컴포넌트를 찾아서 지정

        startPos = new Vector3(0, 0, 0);    // 공의 초기 위치 저장
        //ballRd.AddForce(0f, 0f, -speed);  // 게임을 시작하면 공이 움직임
        //공의 처음 출발위치를 저장
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && start == false)
        {
            ballRd.AddForce(0f, 0f, -speed);  // 게임을 시작하면 공이 움직임
            start = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("wall"))
        {
            Vector3 currPos = transform.position;    // 공의 현재 위치

            Vector3 incomVec = currPos - startPos;  // 공의 현재 위치 - 출발 위치로 입사각 계산
            Vector3 normalVec = collision.contacts[0].normal;   // 법선백터 노말라이즈
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);  //반사각 계산
            reflectVec = reflectVec.normalized; // 반사각 노말라이즈
            ballRd.velocity = Vector3.zero;
            ballRd.AddForce(reflectVec * speed);    //반사각 방향으로 힘을 가함    
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 currPos = transform.position;    // 공의 현재 위치
            Vector3 playerPos = player.position;
            Vector3 pbPos = currPos - playerPos;
            pbPos.x = pbPos.x / 1.5f;
            pbPos = pbPos.normalized;
            ballRd.velocity = Vector3.zero;
            ballRd.AddForce(pbPos*speed);
          
           
        }
        startPos = transform.position; // 출발위치 새로 저장
    }
}

    

