using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallManager : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if ((transform.position.x - player.position.x) < 10 && (transform.position.x - player.position.x) > 0)
        {
            rigidBody2D.gravityScale = 0.8f;
            UI_Counter._instance.isShaking = true;
            UI_Counter._instance.ShakeCamera();
        }
    }
}
