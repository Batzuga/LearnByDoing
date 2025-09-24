using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpPower;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer rend;

    bool grounded;

    void Start()
    {
        //we get all the necessary components at the start of the game
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Movement();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        //TODO: Make jumping mechanic here, i'm far too lazy
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    void Movement()
    {
        //Getting Left & Right input from WASD. Arrows, joysticks etc.
        float horizontal = Input.GetAxis("Horizontal");
        //setting movement speed by multiplying the imput with speed
        rb.linearVelocityX = horizontal * movementSpeed;
        //getting current speed as an absolute (always positive)
        float currentSpeed = Mathf.Abs(rb.linearVelocityX);

        //checking if speed is more than a treshold of 0.1f
        //and then setting the animator value "moving" so it can play the correct animation
        if(currentSpeed > 0.1f)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }

        //flipping the character texture if moving left or right.
        if(rb.linearVelocityX < -0.1f)
        {
            rend.flipX = true;
        }
        if(rb.linearVelocityX > 0.1f)
        {
            rend.flipX = false;
        }
    }


    //Happens every time we collide with a 2D collider that has marked as trigger.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //we check if the gameobject we collide with has a Goal tag.
        if(collision.gameObject.CompareTag("Goal"))
        {
            bool gameOver = GameManager.instance.MissionComplete();
            if (!gameOver) return;

            rb.linearVelocityX = 0;
            anim.SetBool("Moving", false);
            this.enabled = false;
        }
        //we check if the game object we collide with has Coin scipt (component)
        if(collision.gameObject.GetComponent<Coin>())
        {
            //we call collect from Coin script
            collision.gameObject.GetComponent<Coin>().Collect();
        }
    }
}
