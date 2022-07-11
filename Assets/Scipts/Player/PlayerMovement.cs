using UnityEngine;

namespace Scipts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private float leftRightInput;
        public float speed;
        public float jumpForce;
        private Rigidbody2D rb;

        private Animator anim;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
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
             if (Input.GetButtonDown("Jump"))
             {
                 rb.velocity = new Vector2(rb.velocity.x, jumpForce);
             }
        }

        void AnimationUpdate()
        {
            //check if player is moving right
                        if (leftRightInput > 0)
                        {
                            anim.SetBool("Running", true); //st animation to running right
                        }
                        //check if player is moving left
                        else if (leftRightInput < 0)
                        {
                            anim.SetBool("Running", true); //set animation to running left
                        }
                        //check if player is idle
                        else
                        {
                            anim.SetBool("Running", false); //set animation to idle
                        }
        }
    }
}
