using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plane : MonoBehaviour
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
        moveSpeed = 30f;
        localScale = transform.localScale;
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        //if (gameObject.tag == "dx")
       // {
            dirX = -1f;
            scaleX = 4;
        //}
        /*else if (gameObject.tag == "sx")
        {
            dirX = -1f;
            scaleX = 5;
        } */

    }

    void Update()
    {
        if (onWall())
        {
            dirX *= -1f;
            scaleX *= -1;
            face();
            //gameObject.SetActive(false)
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


    private void face()
    {
        transform.localScale = new Vector3(scaleX, localScale.y, localScale.z);
    }
}

