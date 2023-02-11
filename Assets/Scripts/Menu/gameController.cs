using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public static gameController controller;
    public PlayerMovement player;
    public int score;
    // Start is called before the first frame update
    private void Awake()
    {
        if (controller == null)
        {
            controller = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (controller != this) {
            Destroy(gameObject);
        }


    }
}
