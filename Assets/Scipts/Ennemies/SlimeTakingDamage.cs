using UnityEngine;

namespace Scipts.Ennemies
{
    public class SlimeTakingDamage : EnnemyTakingDamage
    {
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            moveScript = GetComponent<SlimeMovement>();
            coll = GetComponent<BoxCollider2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (rb.velocity.x == 0f && healtPoints > 0)
            {
                moveScript.enabled = true;
            }

            if (healtPoints == 0 && IsGrounded())
            {
                rb.bodyType = RigidbodyType2D.Static;
                coll.enabled = false;
            }

        }
        protected void OnTriggerEnter2D(Collider2D col) //when ennemy gets hit by player
        {
            if (col.gameObject.CompareTag("heroAttack"))
            {
                Damaged();
                Knockback();
            }
          
        }

    }
}
