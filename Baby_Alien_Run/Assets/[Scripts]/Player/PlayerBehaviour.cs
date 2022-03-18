using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;

    [Header("Ground Detection")]
    public Transform groundCheck;
    public float groundRadius, jumpForce;
    public LayerMask groundLayerMask;
    
    [HideInInspector]
    public bool isGrounded, isGameOver;
    
    [HideInInspector]
    public Animator anim;
    
    public AudioSource jumpSound;

    private Rigidbody2D rigidBody2D;
    public static PlayerBehaviour _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        anim = transform.GetComponent<Animator>();
    }

    void Update()
    {
        if (!isGameOver)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayerMask);

            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (isGrounded && Input.GetKeyDown("space"))
            {
                anim.Play("Player_Jumps");
                rigidBody2D.AddForce(new Vector2(2, 25), ForceMode2D.Impulse);
                jumpSound.Play();
            }
        } else
        {
            //transform.GetComponent<Animator>().speed = 0;
        }
    }

    public void PlayerDies()
    {
        //anim.SetBool ("isDies", true); // Run State
        Debug.Log("PlayerDies");
        anim.Play("Player_Dies");
    }

    public void RespawnPlayer ()
    {
        Debug.Log("Respawned...");
        transform.position = UI_Counter._instance.respawnPosition;
        PlayerBehaviour._instance.isGameOver = false;
        UI_Counter._instance.isDead = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        //Gizmos.DrawLine(transform.position, groundCheck.position);
    }
}