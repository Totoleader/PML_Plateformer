using UnityEngine;

namespace Scipts.Ennemies.Bat
{
    public class BatTakingDamage : EnnemyTakingDamage
    {
        private BatMovement moveScript;

        
        
        
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            moveScript = GetComponent<BatMovement>();
            coll = GetComponent<BoxCollider2D>();
        }

        // Update is called once per frame
        void Update()
        {

            if (IsGrounded() && healtPoints == 0)
            {
                coll.enabled = false;
                rb.bodyType = RigidbodyType2D.Static; //**changer pour on trigger si possible
            }
            

        }
        protected void OnTriggerEnter2D(Collider2D col) //when ennemy gets hit by player
        {
            if (col.gameObject.CompareTag("heroAttack"))
            {
                moveScript.enabled = false;
                Damaged();
                Knockback();
                OnDeath();
            }
        }

        private void OnDeath()
        {
            if (healtPoints == 0)
            {
                rb.gravityScale = 1f;
                DropLoot();
            }
        }

        protected override void EnableMovescipt()
        {
            if (healtPoints != 0)
            {
                moveScript.enabled = true;
            }
        }
    }
}
