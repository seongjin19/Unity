using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 360f;
    Rigidbody rb;
    public float jumpPower = 5f;
    public bool move = false;
    public float count = 3f;
    public bool isJumping = false;
    public GameObject Kunai;
    private bool isAttack = false;
    public float Acount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>(); 
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        count += Time.deltaTime;
        if (isAttack == false) 
        { 
            float mv = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            float rot = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

            transform.Translate(0,0,mv);
            transform.Rotate(0,rot,0);
            if (Input.GetButtonDown("Jump") && isJumping == false)
            {
                rb.velocity = new Vector3(mv, jumpPower, rot);
                animator.SetBool("Jump", true);
                isJumping = true;
            }
            else
            {
                animator.SetBool("Jump", false);
            }
        }
        
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("Move", true);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("BackMove", true);
            
        }
        else if(Input.GetButtonDown("Fire") && count > 3.0f)
        {
            
            
            isAttack = true;
            Kunai.GetComponent<PlayerShoot>().Fire();
            animator.SetBool("Attack", true);
            count = 0;
            while (Acount < 3.0f)
            {
                Acount += Time.deltaTime;
            }
            Acount = 0;
            isAttack = false;
            

        }
        else
        {
            
            animator.SetBool("Attack", false);
            animator.SetBool("Move", false);
            animator.SetBool("BackMove", false);
        }
        
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {    
        if (collision.collider.CompareTag("Plain"))
        {
            isJumping = false;
            
        }
    }
}

