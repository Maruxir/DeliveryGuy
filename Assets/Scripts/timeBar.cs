using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeBar : MonoBehaviour
{
    public Slider timeSlider;
    public float gameTime;
    private bool stopTimer;
    private Animator anim;

     private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        stopTimer = false;
        timeSlider.maxValue = gameTime;
        timeSlider.value = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        float time = gameTime - Time.time;

        if (time <= 0) stopTimer = true;
        if (stopTimer == false) timeSlider.value = time;
        if (timeSlider.value <= 10) anim.SetBool("last10", true);
    }
}
