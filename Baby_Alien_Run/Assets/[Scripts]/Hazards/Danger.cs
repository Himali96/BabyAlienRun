using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !UI_Counter._instance.isDead)
        {
            UI_Counter._instance.isDead = true;
            UI_Counter._instance.LifeCounter(other.gameObject);
            UI_Counter._instance.deathSound.Play();
            PlayerBehaviour._instance.isGameOver = true;
            if (!UI_Counter._instance.isLifeOver)
                PlayerBehaviour._instance.PlayerDies();
            else
            {
                other.transform.GetComponent<Animator>().speed = 0;
                other.transform.position = UI_Counter._instance.respawnPosition;
            }
        }
    }
}