using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove2 : MonoBehaviour
{
    public float mSpeed;
    private float y;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        y += Time.deltaTime * mSpeed;                       //���ۺ��� ���ư��� ��ֹ�
        transform.rotation = Quaternion.Euler(0, y, 0); 
    }
}
