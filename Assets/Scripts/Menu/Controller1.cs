using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Controller1 : MonoBehaviour
{
    public static string hand;
    public GameObject dx;
    public GameObject sx;
    // Start is called before the first frame update
    void Start()
    {
        if (hand == null)
        {
            dxHand();
        }
        else
        {
            if (hand == "dx")
            {
                dx.GetComponent<Image>().color = Color.green;
                sx.GetComponent<Image>().color = Color.white;
            }
            else if (hand == "sx")
            {
                sx.GetComponent<Image>().color = Color.green;
                dx.GetComponent<Image>().color = Color.white;
            }
        }
     }

     public void dxHand()
     {
         hand = "dx";
        Start();
     }

     public void sxHand()
     {
         hand = "sx";
        Start();
    } 
    
}

