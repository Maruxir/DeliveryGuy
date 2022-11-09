using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMusicController : MonoBehaviour
{
    public static EndMusicController instance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
