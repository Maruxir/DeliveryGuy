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
        MusicControlScript.instance.GetComponent<AudioSource>().Pause();
        MusicMenu.instance.GetComponent<AudioSource>().Play();
    }

    public void reset()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
}
