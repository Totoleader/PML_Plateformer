using UnityEngine;

namespace Scipts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private float leftRightInput;
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;
        [SerializeField] private LayerMask jumpableGround;
        private Rigidbody2D rb;
        private BoxCollider2D coll;

        private Animator anim;
        private SpriteRenderer sprite;


        private enum MovementState
        {
            idle,
            running,
            jumping,
            falling
        }

        MovementState state;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            sprite = GetComponent<SpriteRenderer>();
            coll = GetComponent<BoxCollider2D>();
        }

        // Update is called once per frame
        void Update()
        {
            MovementUpdate();
            AnimationUpdate();
        }

        void MovementUpdate()
        {
            //left-right movement
            leftRightInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(speed * leftRightInput, rb.velocity.y);

            //jump
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        private bool IsGrounded() // checks if player is on the ground and can jump
        {
            return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        }

        void AnimationUpdate() //Updates movement animations
        {
            //check if player is moving right

            if (leftRightInput > 0) //set animation to running right
            {
                state = MovementState.running;
                sprite.flipX = false;
            }
            //check if player is moving left
            else if (leftRightInput < 0) //set animation to running left
            {
                state = MovementState.running;
                sprite.flipX = true;
            }

            else //check if player is idle
            {
                state = MovementState.idle;
            }


            if (rb.velocity.y > .01f)
            {
                state = MovementState.jumping;
            }
            else if (rb.velocity.y < -.01f)
            {
                state = MovementState.falling;
            }

            anim.SetInteger("State", (int)state);
        }
    }
}