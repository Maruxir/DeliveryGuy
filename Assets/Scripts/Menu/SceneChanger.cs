using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*Da inizio al gioco*/
public class SceneChanger : MonoBehaviour
{
    public GameObject bike;
    private Animator anim;
    public GameObject levelsPanel;
    public GameObject menuPanel;
    public void start()
    {
        anim = bike.GetComponent<Animator>();
        /* SceneManager.LoadScene("SampleScene");
        MusicMenu.instance.GetComponent<AudioSource>().Pause();
        MusicControlScript.instance.GetComponent<AudioSource>().Play(); */

        StartCoroutine(bikeGo());
        //bikeGo();
    }

    public IEnumerator bikeGo()
    {
        anim.SetBool("play", true);
        yield return new WaitForSeconds(2);

        levelsPanel.gameObject.SetActive(true);
        menuPanel.gameObject.SetActive(false);

    }

    public void StartGame() 
    {
        SceneManager.LoadScene("SampleScene");
        MusicMenu.instance.GetComponent<AudioSource>().Pause();
        if (MusicPlayer.instance != null)
            MusicPlayer.instance.GetComponent<AudioSource>().Play();
    }
}
