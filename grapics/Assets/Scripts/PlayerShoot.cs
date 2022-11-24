using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Rigidbody Kunai;
    public Transform fireTransform;
    public GameObject player;
    //public Animator Sanimator;
    //public float count = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Sanimator = GetComponentInParent<Player>().animator;
    }

    // Update is called once per frame
    void Update()
    {
        //count += Time.deltaTime;
        //if(Input.GetButtonDown("Fire") && count > 3)
        //{
        //    Fire();
        //    Sanimator.SetBool("Attack", true);
        //    count = 0;
        //}
        //else
        //{
        //    Sanimator.SetBool("Attack", false);
        //}
     
    }

    public void Fire()
    {
       Rigidbody shellInstance = Instantiate(Kunai, fireTransform.position,fireTransform.rotation) as Rigidbody;
       shellInstance.velocity = 20.0f * fireTransform.forward;
        
    }
}
