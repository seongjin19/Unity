using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal2 : MonoBehaviour
{
    public GameObject potal2;
    public GameObject player;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && player.GetComponent<Player>().Spotal == true)
        {


            pos = new Vector3(potal2.transform.position.x, potal2.transform.position.y, potal2.transform.position.z);

            collision.transform.position = pos;

        }
    }
}
