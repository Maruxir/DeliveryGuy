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

    /* public void maxHealt( int healt)
     {
         slider.maxValue = healt;
         slider.value = healt;

         fill.color = gradient.Evaluate(1f);
     }
     public void setHealt(int healt) 
     {
         slider.value = healt;

         fill.color = gradient.Evaluate(slider.normalizedValue);
     }

     */
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
            MusicControlScript.instance.GetComponent<AudioSource>().Pause();
            EndMusicController.instance.GetComponent<AudioSource>().Play();

        }


    }



}
