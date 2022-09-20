using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject menu;
    private bool muted = false;
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
        if (muted == false)
        {
            AudioListener.pause = true;
            muted = true;
        }
        else if (muted == true) {
            AudioListener.pause = false;
            muted = false;
        }
    }
}
