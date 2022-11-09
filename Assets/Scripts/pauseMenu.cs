using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static pauseMenu instance;
    public GameObject menu;
    public GameObject offMusic;

    public void Start()
    {
        if (AudioListener.pause == true) { offMusic.SetActive(true); }
        else { offMusic.SetActive(false); }
    }

    public void pause()
    {
        Time.timeScale = 0;
        menu.gameObject.SetActive(true);
    }

    public void play()
    {
        Time.timeScale = 1;
        menu.gameObject.SetActive(false);
    }

    public void home()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
        MusicControlScript.instance.GetComponent<AudioSource>().Pause();
        MusicMenu.instance.GetComponent<AudioSource>().Play();
    }

    public void reset()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void mute()
    {
        if (AudioListener.pause == false)
        {
            AudioListener.pause = true;
            offMusic.SetActive(true);
        }
        else if (AudioListener.pause == true) {
            AudioListener.pause = false;
            offMusic.SetActive(false);
        }
    }
}
