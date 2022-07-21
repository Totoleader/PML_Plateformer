using System;
using UnityEngine;

namespace Scipts.Ennemies
{
    public class EnnemyTakingDamage : MonoBehaviour
    {
        private SlimeMovement moveScript;
        private Animator anim;
        [SerializeField] private int healtPoints;
        private Rigidbody2D rb;
        private BoxCollider2D coll;
        [SerializeField] private float knockbackForce;
        [SerializeField] private LayerMask ground;

        [SerializeField] private GameObject Player;
        private Vector2 playerEnnemyDistance;

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

        private void OnTriggerEnter2D(Collider2D col) //when ennemy gets hit by player
        {
            if (col.gameObject.CompareTag("heroAttack"))
            {
                Damaged();
                Knockback();
            }
          
        }

        private void Damaged() //when ennemy is hit
        {
            healtPoints -= 1;
            anim.SetTrigger("damaged");
            moveScript.enabled = false;

            if (healtPoints == 0) // on death
            {
                anim.SetTrigger("death");
                //coll.enabled = false;
                rb.velocity = Vector2.zero;
            }
            
        }

        private void Knockback() //the ennemy knockback after a hit
        {
            var playerPosition = Player.transform.position;
            var ennemyPosition = transform.position;
            var playerEnnemyDistanceX = ennemyPosition.x - playerPosition.x;
            var playerEnnemyDistanceY = playerPosition.y - ennemyPosition.y;
            double normeDistance;
            Vector2 vecteurUnitaire;

            if (healtPoints > 0)
            {
                playerEnnemyDistance =
                    new Vector2(playerEnnemyDistanceX, playerEnnemyDistanceY); //coordonées distance

                normeDistance = Math.Sqrt(Math.Pow(playerEnnemyDistanceX, 2) + Math.Pow(playerEnnemyDistanceY, 2)); //norme

                vecteurUnitaire = playerEnnemyDistance / (float)normeDistance; //vecteur unitaire (direction) entre player et ennemy

                rb.AddForce(vecteurUnitaire * knockbackForce); 
            }
        }
        
        
        private bool IsGrounded() // checks if player is on the ground and can jump
        {
            return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, ground);
        }
    }
}