using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip jumpSound;
    public float jumpPower;
    float curTime = 0f;
    string timerText;
    // Start is called before the first frame update
    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.jumpSound;
        this.audio.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            this.audio.Play();
            GetComponent<Rigidbody>().velocity = new Vector3(0f, jumpPower, 0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("WALL"))
        {
            SceneManager.LoadScene("main");
        }
    }
    private void OnGUI()
    {
        string timerText = "Timer: " + curTime;
        Rect textpos = new Rect(100, 100, 200, 40);
        GUI.Label(textpos, timerText);
    }
}
