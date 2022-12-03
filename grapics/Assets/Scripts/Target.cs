using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public bool Down = false;
    public GameObject Irongrate;
    public float moveSpeed;
    public float initPositionY;
    // Start is called before the first frame update
    void Start()
    {
        initPositionY = Irongrate.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Down == true)
        {
            Debug.Log("Down");
            Irongrate.transform.position = Irongrate.transform.position + new Vector3(0, -1, 0) * moveSpeed * Time.deltaTime;
            if (Irongrate.transform.position.y < initPositionY - 15.0f)
            {
                Destroy(Irongrate);
                Destroy(gameObject,0.5f);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Kunai"))
        {
            Destroy(other.gameObject);
            Down = true;
        }
    }
}
