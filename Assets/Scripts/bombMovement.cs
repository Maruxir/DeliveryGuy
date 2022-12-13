using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombMovement : MonoBehaviour
{
     private Rigidbody2D rb;
     private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "bombUp")
        rb.velocity = new Vector2(0f, 3f);
        else if(gameObject.tag == "bombDown")
        rb.velocity = new Vector2(0f, -3f);

        if (rb.position.y <= 20 || rb.position.y >= 40) change();
    }

    private void change()
    {
        if (rb.position.y >= 40 && gameObject.tag == "bombUp")
            gameObject.tag = "bombDown";
        else if (rb.position.y <= 20 && gameObject.tag == "bombDown")
            gameObject.tag = "bombUp";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
            Physics2D.IgnoreCollision(collision.collider, boxCollider);
    }
}
