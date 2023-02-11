using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public TMP_Text score;

    void Start()
    {
        int temp = PlayerPrefs.GetInt("score");
        score.text = "You earned: " + temp.ToString() + " points!";
    } 

    public void home()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
        EndMusic.instance.GetComponent<AudioSource>().Pause();
        if (MusicMenu.instance != null)
            MusicMenu.instance.GetComponent<AudioSource>().Play();
    }

    public void reset()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
        EndMusic.instance.GetComponent<AudioSource>().Pause();
        if (MusicPlayer.instance != null)
            MusicPlayer.instance.GetComponent<AudioSource>().Play();
    }
}
