using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer rend;

    bool grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Goal"))
        {
            GameManager.instance.MissionComplete();
            anim.SetBool("Moving", false);
            this.enabled = false;
        }
    }
}
