using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
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
}
