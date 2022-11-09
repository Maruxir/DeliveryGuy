using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask wallLayer;
    private float dirX;
    private Rigidbody2D rb;
    private Vector3 localScale;
    private float moveSpeed;
    private float scaleX;


    // Update is called once per frame
    private void Start()
    {
        moveSpeed = 10f;
        localScale = transform.localScale;
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        if (gameObject.tag == "dx")
        {
            dirX = 1f;
            scaleX = 6;
        }
        else if (gameObject.tag == "sx")
        {
            dirX = -1f;
            scaleX = -6;
        }
            
    }

    void Update()
    {
        if (onWall())
        {
            dirX *= -1f;
            scaleX *= -1;
            cos();
            changeY();
            face();
        }


    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    private void cos() {
        if (gameObject.tag == "dx")
            gameObject.tag = "sx";
        else if(gameObject.tag == "sx")
            gameObject.tag = "dx";
    }

    private void changeY() {
        if (gameObject.tag == "dx")
            transform.position = new Vector3(transform.position.x, transform.position.y - 5);
        else if (gameObject.tag == "sx")
            transform.position = new Vector3(transform.position.x, transform.position.y + 5);
    }

    private void face() {
      /* if (gameObject.tag == "dx")
            transform.localScale =new Vector3(5, localScale.y, localScale.z);
        else if (gameObject.tag == "sx") */
            transform.localScale = new Vector3( scaleX , localScale.y, localScale.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag != "Player")
            Physics2D.IgnoreCollision(collision.collider, boxCollider);
    }
}
