using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCommand : MonoBehaviour
{
    public GameObject dx;
    public GameObject sx;
    private string whatHand = Controller1.hand;
    // Start is called before the first frame update
    void Start()
    {
        if (whatHand == "dx" || whatHand == null)
        {
            dx.SetActive(true);
            sx.SetActive(false);
        }
        else if (whatHand == "sx") {
            sx.SetActive(true);
            dx.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
