using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlain : MonoBehaviour
{
    float initPositionZ;
    public float distance;
    public float turningPoint;
    //UD_Floor & LR_Floor
    public bool turnSwitch;
    public float moveSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        initPositionZ = transform.position.z;
        turningPoint = initPositionZ - distance;
    }

    // Update is called once per frame
    void Update()
    {
        leftRight2();
    }
    void leftRight2()
    {

        float currentPositionZ = transform.position.z;

        if (currentPositionZ >= initPositionZ + distance)
        {
            turnSwitch = false;
        }
        else if (currentPositionZ <= turningPoint)
        {
            turnSwitch = true;
        }

        if (turnSwitch)
        {
            transform.position = transform.position + new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position = transform.position + new Vector3(0, 0, -1) * moveSpeed * Time.deltaTime;
        }

    }
}
