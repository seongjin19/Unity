using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float minY, maxY;

    [Range(1,100)]
    public float mSpeed;

    private int sign = -1;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
   {
        
        transform.position += new Vector3(0, mSpeed * Time.deltaTime * sign, 0);
        if(transform.position.y <= minY || transform.position.y >= maxY)
        {
            sign *= -1; 
        }
         
    }
}
