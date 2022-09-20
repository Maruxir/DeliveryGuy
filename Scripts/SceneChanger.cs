using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private string hand = "dx";
    public void start()
    {
        SceneManager.LoadScene("SampleScene");
        MusicMenu.instance.GetComponent<AudioSource>().Pause();
        MusicControlScript.instance.GetComponent<AudioSource>().Play();
    }
}
