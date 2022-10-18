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
        y += Time.deltaTime * mSpeed;                       //빙글빙글 돌아가는 장애물
        transform.rotation = Quaternion.Euler(0, y, 0); 
    }
}
