using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeBar : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    private Animator anim;
    public GameObject end;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void life(int count) 
    {   if (count == 3)
        {
            life3.SetActive(true);
            life2.SetActive(true);
            life1.SetActive(true);
        }
        else if (count == 2)
        {
            life3.SetActive(false);
            life2.SetActive(true);
            life1.SetActive(true);
            anim.SetBool("last", false);
        }
        else if (count == 1)
        {
            life3.SetActive(false);
            life2.SetActive(false);
            life1.SetActive(true);
            anim.SetBool("last", true);
        }

        else if (count == 0)
        {
            life1.SetActive(false);
            SceneManager.LoadScene("DeadEnd");
            MusicPlayer.instance.GetComponent<AudioSource>().Pause();
            if(EndMusic.instance != null)
                EndMusic.instance.GetComponent<AudioSource>().Play();

        }


    }



}
