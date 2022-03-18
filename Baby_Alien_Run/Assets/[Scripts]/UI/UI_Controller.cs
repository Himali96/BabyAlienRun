using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UI_Controller : MonoBehaviour
{
    public static UI_Controller _instance;

    public TMP_Text txt_PopUp;
    public Transform player;
    public GameObject popUp, loadGameBtn;
    public RawImage musicIcon, soundIcon;
    public List<AudioSource> soundClips;
    public AudioSource music;
    public Texture muteSound, unmuteSound, muteMusic, unmuteMusic;
    
    bool isSoundMute, isMusicMute;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
   
    public void NewGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                                Application.Quit();
        #endif
    }

        public void MuteSound ()
    {
        isSoundMute = !isSoundMute;
        if (!isSoundMute)
        {
            for (int i = 0; i < soundClips.Count; i++)
            {
                soundClips[i].enabled = true;
            }
            soundIcon.GetComponent<RawImage>().texture = unmuteSound;
        } 
        else
        {
            for (int i = 0; i < soundClips.Count; i++)
            {
                soundClips[i].enabled = false;
            }
            soundIcon.GetComponent<RawImage>().texture = muteSound;
        }
    }

    public void MuteMusic ()
    {
        isMusicMute = !isMusicMute;
        if (!isMusicMute)
        {
            music.Play();
            musicIcon.GetComponent<RawImage>().texture = unmuteMusic;
        }
        else
        {
            music.Pause();
            musicIcon.GetComponent<RawImage>().texture = muteMusic;
        }
    }

    /*
   public void LoadGame ()
   {
       popUp.SetActive(false);
       loadGameBtn.SetActive(false);
       PlayerBehaviour._instance.isGameOver = false;
       PlayerBehaviour._instance.anim.Play("Player_Run");
   }

    public void OpenPopUp ()
    {
        txt_PopUp.text = "Game Settings";
        loadGameBtn.SetActive(true);
        popUp.SetActive(true);
        PlayerBehaviour._instance.isGameOver = true;
    }

   public void TryAgain ()
   {
       player.position = UI_Counter._instance.respawnPosition;
       PlayerBehaviour._instance.anim.Play("Player_Run");
       loadGameBtn.SetActive(false);
       popUp.SetActive(false);
   }
   */
}
