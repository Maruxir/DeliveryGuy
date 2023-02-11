using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour
{   
    public Text counter;
    public Text max; 
    // Start is called before the first frame update
    void Start()
    {
        counter.text = 0.ToString();
    }

    // Update is called once per frame
    public void change(int value, int count)
    {
        if (value == 1)
            counter.text = count.ToString();
        else
            max.text = "/" + count.ToString();
    }
}
