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

        transform.position += new Vector3(-mSpeed * Time.deltaTime * sign, 0, 0); // 위 아래로 움직이는 장애물
        if (transform.position.x <= minX || transform.position.x >= maxX)         // 최대, 최소 Y값을 설정하여 
        {
            sign *= -1; // 최소, 최대가 되면 sign값을 반대로 하여 방향 전환
        }

    }
}
