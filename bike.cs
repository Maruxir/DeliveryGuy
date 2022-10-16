using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bike : MonoBehaviour
{
    private Animator anim;

    public void go()
    {
        anim.SetBool("play", true);
    }
}
