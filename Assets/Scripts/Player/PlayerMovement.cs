
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask obsLayer;

    public GameObject fire;
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
    public int score;
    private void Start()
    {
        score = 0;
        count = 3;
        jumpSpeed = this.speed;
        number = 0;
        PlayerPrefs.SetInt("score", 4);
        int stampa = PlayerPrefs.GetInt("score");
        Debug.Log("p" + stampa);
        PlayerPrefs.SetInt("score", 56);
       stampa = PlayerPrefs.GetInt("score");
        Debug.Log("p" + stampa);
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }


    private void Update()
    {
        float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;

        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded())
            jump();

        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
    }

    private void jump() 
    {
        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        anim.SetTrigger("jump");
    }

  private void OnCollisionEnter2D(Collision2D collision)
   {
        if (((collision.gameObject.tag == "dx") || (collision.gameObject.tag == "sx")) && fired == false)
        {
            count = count - 1;
            changeLife(count);
            score = (count * 3) + (number * 9);
            PlayerPrefs.SetInt("score", score);
            if (count == 0)
            {
                gameObject.SetActive(false);
            }
        }
        else if (fired == true  && (collision.gameObject.tag == "dx" || collision.gameObject.tag == "sx" || collision.gameObject.tag == "bombUp" || collision.gameObject.tag == "bombDown")) 
        {
            StartCoroutine(destroyEverything(collision.gameObject));
        }
        
        if (collision.gameObject.tag == "fire")
        {
            StartCoroutine(onFire());
        }

        if (collision.gameObject.tag == "heart") 
        {
            count = count + 1;
            changeLife(count);
        }

        if (collision.gameObject.tag == "food") 
        {
            number++;
            text.change(1, number);
            score = (count * 3) + (number * 9);
            PlayerPrefs.SetInt("score", score);
            if (number == 14)
            {
                SceneManager.LoadScene("WinEnd");
                MusicPlayer.instance.GetComponent<AudioSource>().Pause();
                if (WinMusic.instance != null)
                    WinMusic.instance.GetComponent<AudioSource>().Play();
            }
            collision.gameObject.SetActive(false);
             StartCoroutine(foodRecreate(collision.gameObject));
        }

        if ((collision.gameObject.tag == "bombUp" || collision.gameObject.tag == "bombDown") && fired == false)
        {
            number = number -2;
            if (number < 0) { number = 0; }
            count = count - 1;
            changeLife(count);
            text.change(1, number);
            collision.gameObject.SetActive(false);
        }
    }

    public IEnumerator destroyEverything(GameObject collision)
    {
        collision.SetActive(false);
       // fire.gameObject.SetActive(true);
        yield return new WaitForSeconds(10);
        collision.SetActive(true);
       // fire.gameObject.SetActive(false);
    }

    public IEnumerator foodRecreate(GameObject collision)
    {
        collision.SetActive(false);
        yield return new WaitForSeconds(15);
        collision.SetActive(true);
    }


    public IEnumerator onFire() 
    {
        fired = true;
        fire.gameObject.SetActive(true);
        this.speed = 80;
        yield return new WaitForSeconds(10);
        this.speed = 15;
        fire.gameObject.SetActive(false);
        fired = false;
    }

    private bool isGrounded() {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private void changeLife(int count) 
    {
        if (count > 3) { count = 3;  }
        lifeBar.life(count);
    }

}
