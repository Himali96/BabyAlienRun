using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Cinemachine;

public class UI_Counter : MonoBehaviour
{
    public static UI_Counter _instance;
    public int coinCount, diamondValue, keyValue, lifesLeft = 3, score;
    public TextMeshPro txt_CoinCount, txt_DiamondCount, txt_KeyCount, txt_Score;
    public List<SpriteRenderer> lifeSprites;
    public Sprite life, death;
    public Vector2 respawnPosition;
    public bool isDead, isShaking, isLifeOver, isZoomingIn, isZoomingOut;
    public GameObject virtualCam, diamondParticle, keyParticle;
    public float shakingTime, zoomingTime, timer;
    public AudioSource deathSound;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    private void Update()
    {
        if (Time.frameCount % 20 == 0 && !PlayerBehaviour._instance.isGameOver)
        {
            score++;
            txt_Score.text = score.ToString();
        }
        if (isShaking && shakingTime < 0.5f) shakingTime = shakingTime + 0.05f;
        else
        {
            isShaking = false;
            shakingTime = 0;
            virtualCam.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 8;
        }

        if (isZoomingIn && zoomingTime < 1)
        {
            zoomingTime = zoomingTime + 0.005f;
            ZoomCamera();
        }
        else if (isZoomingIn)
        { 
            isZoomingIn = false;
            isZoomingOut = true;
        }
        if (isZoomingOut && zoomingTime > 0)
        {
            zoomingTime = zoomingTime - 0.005f;
            ZoomCamera();
        }
        else if (isZoomingOut)
        {
            zoomingTime = 0;
            ZoomCamera();
            isZoomingOut = false;
        }

    }
    public void Coin ()
    {
        coinCount++;
        txt_CoinCount.text = coinCount.ToString();
    }

    public void Diamond ()
    {
        diamondValue++;
        txt_DiamondCount.text = diamondValue.ToString();
    }

    public void Key ()
    {
        keyValue++;
        txt_KeyCount.text = keyValue.ToString();
    }

    public void LifeCounter (GameObject player)
    {
        lifesLeft--;
        if (lifesLeft < 1)
        {
            UI_Controller._instance.popUp.SetActive(true);
            PlayerBehaviour._instance.isGameOver = true;
            isLifeOver = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else lifeSprites[lifesLeft].GetComponent<SpriteRenderer>().sprite = death;
        deathSound.Play();
    }

    public void ShakeCamera ()
    {
        virtualCam.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 8 + Mathf.Abs (Mathf.Sin(Time.time * 30f) * 0.6f);
    }

    public void ZoomCamera()
    {
        virtualCam.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 8 - zoomingTime;
    }
}
