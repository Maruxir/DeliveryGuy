using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    private BoxCollider2D boxCollider;
   // private BoxCollider2D colCollider;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
                gameObject.SetActive(false);
        else if ((collision.gameObject.tag == "dx") || (collision.gameObject.tag == "sx")) 
        {
            Physics2D.IgnoreCollision(collision.collider, boxCollider);
        }
    }

}
