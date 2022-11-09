using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    public GameObject off;
    public static SoundManager instance;
    void Start()
    {
        if (AudioListener.pause == true) { off.SetActive(true); }
        else { off.SetActive(false); }
    }

    public void OnButtonPress()
    {
        if (AudioListener.pause == true)
        {
            AudioListener.pause = false;
            off.SetActive(false);
        }
        else if (AudioListener.pause == false) 
        {
            AudioListener.pause = true;
            off.SetActive(true);
        }
    }
}
