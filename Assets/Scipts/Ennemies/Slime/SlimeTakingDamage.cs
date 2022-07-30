using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scipts.Ennemies.Slime
{
    public class SlimeTakingDamage : EnnemyTakingDamage
    {
        private SlimeMovement moveScript;
        

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
                moveScript.enabled = false;
                Damaged();
                Knockback();
                OnDeath();
            }
        }

        protected override void EnableMovescipt()
        {
            if (healtPoints != 0)
            {
                moveScript.enabled = true;
            }
        }

        private void OnDeath()
        {
            if (healtPoints == 0)
            {
               DropLoot();
            }
        }
    }
}