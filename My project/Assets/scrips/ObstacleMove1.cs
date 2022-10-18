using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove1 : MonoBehaviour
{
    public float minX, maxX;

    [Range(1, 100)]
    public float mSpeed;
    private int sign = -1;
    // Start is called before the first frame update
    void Start()
    {
        minX = -8.9f;
        maxX = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += new Vector3(-mSpeed * Time.deltaTime * sign, 0, 0); // �� �Ʒ��� �����̴� ��ֹ�
        if (transform.position.x <= minX || transform.position.x >= maxX)         // �ִ�, �ּ� Y���� �����Ͽ� 
        {
            sign *= -1; // �ּ�, �ִ밡 �Ǹ� sign���� �ݴ�� �Ͽ� ���� ��ȯ
        }

    }
}
