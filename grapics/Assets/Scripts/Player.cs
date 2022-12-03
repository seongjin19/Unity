using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public GameObject Fire1;
    public GameObject Fire2;  
    public GameObject Fire3;
    AudioSource audioSource;
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
    private bool Adelay = false;
    public float Fcount = 0;
    private bool Fdelay = false;
    public bool Spotal = false;
    private bool clear1 = false;
    private bool clear2 = false;
    private bool clear3 = false;
    public GameObject Door1;
    public GameObject Door2;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>(); 
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        count += Time.deltaTime;
        if (Adelay == true)
        {
            Acount += Time.deltaTime;
            if (Acount > 1.5f)
            {
                isAttack = false;
                Adelay = false;
                Acount = 0;
            }
        }
        if (Fdelay == true)
        {
            Fcount += Time.deltaTime;
            if (Fcount > 0.5f)
            {
                Kunai.GetComponent<PlayerShoot>().Fire();
                Fdelay = false;
                Fcount = 0;
                audioSource.Play();
            }
        }
        if (Fdelay == true)
        {
            
        }
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

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("Move", true);
            animator.SetBool("BackMove", false);
            animator.SetBool("Attack", false);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("BackMove", true);
            animator.SetBool("Attack", false);
            animator.SetBool("Move", false);
        }
        else if (Input.GetButtonDown("Fire") && count > 3.0f)
        {
            Adelay = true;
            Fdelay = true;
            isAttack = true;
            animator.SetBool("Attack", true);
            animator.SetBool("Move", false);
            animator.SetBool("BackMove", false);
            count = 0;
        }
        else
        {
            
            animator.SetBool("Attack", false);
            animator.SetBool("Move", false);
            animator.SetBool("BackMove", false);
        }
        if (clear3 == true)
        {
            Destroy(Door1);
            Destroy(Door2);
        }
        
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Plain"))
        {
            isJumping = false;
        }
        if (collision.gameObject == GameObject.Find("quest1"))
        {
            clear1 = true;
            Destroy(Fire1);
        }
        if (collision.gameObject.name == "quest2" && clear1 == true)
        {
            clear2 = true;
            Destroy(Fire2);
        }
        if (collision.gameObject.name == "quest3" && clear2 == true)
        {
            clear3 = true;
            Destroy(Fire3);
        }
        if (collision.gameObject.name == "EndLine")
        {
            SceneManager.LoadScene("GameClear");
        }



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gem"))
        {
            Spotal = true;
            Destroy(other.gameObject);
        }
    }
}

