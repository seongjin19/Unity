using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject wallPrefab;
    public float interval;
    private float Range = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateWall());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CreateWall()
    {
        while(true)
        {
            float wallY = Random.Range(-Range, Range);
            Vector3 wallPos = new Vector3(transform.position.x, wallY, transform.position.z);
            Instantiate(wallPrefab, wallPos, transform.rotation);
            yield return new WaitForSeconds(interval);
        }
    }
}
