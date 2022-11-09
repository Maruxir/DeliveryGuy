using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine;

public class bike : MonoBehaviour
{
    private Animator anim;

    public void start()
    {
        anim = GetComponent<Animator>();
    }
    public void go()
    {
        anim.SetBool("play", true);
    }
}
