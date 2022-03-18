using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSpikes : MonoBehaviour
{
    public Transform player;
    public float count;

    private void Update()
    {
        if (Mathf.Abs(transform.position.x - player.position.x) < 10)
        {
            if (transform.position.y < -2.6f)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + count);
            }
        }
        else 
        {
            if (transform.position.y > -3.2)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - count);
            }
        }
    }
}
