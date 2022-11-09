using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject bike;
    private Animator anim;
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
        yield return new WaitForSeconds(1);

            SceneManager.LoadScene("SampleScene");
            MusicMenu.instance.GetComponent<AudioSource>().Pause();
            MusicControlScript.instance.GetComponent<AudioSource>().Play();
        
    }
}
