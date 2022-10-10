using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : GameManager
{
    public Transform player;
    private Rigidbody ballRd;   //Rigidbody ������Ʈ ����
    public float speed = 100.0f;
    Vector3 startPos; // ���� �����ġ ������ �����ϴ� ����
    

    // Start is called before the first frame update
    void Start()
    {
        ballRd = GetComponent<Rigidbody>();  //Rigidbody ������Ʈ�� ã�Ƽ� ����

        startPos = new Vector3(0, 0, 0);    // ���� �ʱ� ��ġ ����
        //ballRd.AddForce(0f, 0f, -speed);  // ������ �����ϸ� ���� ������
        //���� ó�� �����ġ�� ����
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && start == false)
        {
            ballRd.AddForce(0f, 0f, -speed);  // ������ �����ϸ� ���� ������
            start = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("wall"))
        {
            Vector3 currPos = transform.position;    // ���� ���� ��ġ

            Vector3 incomVec = currPos - startPos;  // ���� ���� ��ġ - ��� ��ġ�� �Ի簢 ���
            Vector3 normalVec = collision.contacts[0].normal;   // �������� �븻������
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);  //�ݻ簢 ���
            reflectVec = reflectVec.normalized; // �ݻ簢 �븻������
            ballRd.velocity = Vector3.zero;
            ballRd.AddForce(reflectVec * speed);    //�ݻ簢 �������� ���� ����    
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 currPos = transform.position;    // ���� ���� ��ġ
            Vector3 playerPos = player.position;
            Vector3 pbPos = currPos - playerPos;
            pbPos.x = pbPos.x / 1.5f;
            pbPos = pbPos.normalized;
            ballRd.velocity = Vector3.zero;
            ballRd.AddForce(pbPos*speed);
          
           
        }
        startPos = transform.position; // �����ġ ���� ����
    }
}

    

