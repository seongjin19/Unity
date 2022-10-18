using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private Rigidbody itemRd;
    public float speed;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(0, 0, -90);
        itemRd = GetComponent<Rigidbody>();
        speed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right*speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EndLine"))
        {
            Destroy(gameObject);
        }
    }
}
