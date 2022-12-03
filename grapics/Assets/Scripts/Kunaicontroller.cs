using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunaicontroller : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plain"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        
    }
}
