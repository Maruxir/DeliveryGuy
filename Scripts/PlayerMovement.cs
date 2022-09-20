
using System;
using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask obsLayer;
    
    private Animator anim;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private int count;
    RectTransform rt;
    float width;
    public int maxHealt = 9;
    public int currentHealt;
    public LifeBar lifeBar;
    private bool fired = false;
    private float jumpSpeed;
    public CounterScript text;
    public int number;

    private void Start()
    {
        count = 3;
        jumpSpeed = this.speed;
        number = 0;
        //currentHealt = maxHealt;
        //lifeBar.maxHealt(maxHealt);
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {

        // float horizontalInput = Input.GetAxis("Horizontal");
        float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        //if (Input.GetKey(KeyCode.Space) && isGrounded())
            //jump();


        if (CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded())
            jump();

        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
    }

    private void jump() {
        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        anim.SetTrigger("jump");
    }

  private void OnCollisionEnter2D(Collision2D collision)
   {
        if (((collision.gameObject.tag == "dx") || (collision.gameObject.tag == "sx")) && fired == false)
        {
            count = count - 1;
            change(count);
            if (count == 0)
            {
                gameObject.SetActive(false);
            }
        }
        else if (fired == true  && (collision.gameObject.tag == "dx" || collision.gameObject.tag == "sx")) 
        {
            StartCoroutine(destroyer(collision.gameObject));
            //collision.gameObject.SetActive(false);
        }
        
        if (collision.gameObject.tag == "fire")
        {
            StartCoroutine(takeFire());
        }

        if (collision.gameObject.tag == "heart") 
        {
            count = count + 1;
            change(count);
        }

        if (collision.gameObject.tag == "food") 
        {
            number++;
            text.change(1, number);
        }
    }

    public IEnumerator destroyer(GameObject collision)
    {
        collision.SetActive(false);
        yield return new WaitForSeconds(10);
        collision.SetActive(true);
    }
    public IEnumerator takeFire() 
    {
        fired = true;
        this.speed = 80;
        yield return new WaitForSeconds(10);
        this.speed = 40;
        fired = false;
    }

    private bool isGrounded() {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private void change(int count) 
    {
        lifeBar.life(count);
        //currentHealt -= damage;
        //lifeBar.setHealt(currentHealt);
    }

}
