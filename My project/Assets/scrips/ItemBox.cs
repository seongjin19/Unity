using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public GameObject Ball;
    public GameObject itemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BALL"))        // ���� �浹�ϸ� ������ �ڽ� �Ҹ� �� ������ ����
        {
            Destroy(gameObject);
            GameObject itemObj = Instantiate(itemPrefab, transform.position, itemPrefab.transform.rotation);
        }
    }
}
