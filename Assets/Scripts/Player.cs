using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpPower;

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer rend;

    [SerializeField] Transform[] groundChecks;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundCheckHeight;

    bool grounded;
    string animationPlayingName;

    GameObject interactionTarget;

    bool catsAreCool = true;

    void Start()
    {
        //we get all the necessary components at the start of the game
        catsAreCool = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        grounded = CheckIfGrounded();
        anim.SetBool("Grounded", grounded);
        Movement();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
        animationPlayingName = anim.GetCurrentAnimatorClipInfo(0)[0].clip.name;
    }

    void Interact()
    {
        //Why is this empty? Who made this!?
    }
    bool CheckIfGrounded()
    {
        bool hits = false;
        for(int i = 0; i < groundChecks.Length; i++)
        {
            Debug.DrawRay(groundChecks[i].position, -groundChecks[i].up * groundCheckHeight);
            RaycastHit2D hit = Physics2D.Raycast(groundChecks[i].position, -groundChecks[i].up, groundCheckHeight, groundLayer);
            if(hit)
            {
                hits = true;
                continue;
            }
        }
        return hits;
    }
    void Jump()
    {
        if(grounded)
        {
            grounded = false;
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
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
        //and then setting the animator value "moving" to true or false so that it can play the correct animation
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
        if(collision.gameObject.GetComponent<Trophy>())
        {
            if(catsAreCool)
            {
                Debug.Log("Meow-ha-haa!");
                return;
            }
            
            bool gameOver = GameManager.instance.MissionComplete(animationPlayingName);
            if (!gameOver) return;

            rb.linearVelocityX = 0;
            anim.SetBool("Moving", false);
            anim.SetBool("Grounded", true);
            this.enabled = false;
        }

        if(collision.gameObject.GetComponent<Coin>())
        {
            collision.gameObject.GetComponent<Coin>().Collect();
        }

        if(collision.gameObject.GetComponent<Door>())
        {
            interactionTarget = collision.gameObject;
            if(collision.transform.childCount > 0)
            {
                collision.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(interactionTarget != null && interactionTarget == collision.gameObject)
        {
            if (collision.transform.childCount > 0)
            {
                collision.transform.GetChild(0).gameObject.SetActive(false);
            }
            interactionTarget = null;
        }
    }
}
