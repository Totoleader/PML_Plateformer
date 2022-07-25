using System;
using UnityEngine;

namespace Scipts.Ennemies
{
    public class EnnemyTakingDamage : MonoBehaviour
    {
        protected SlimeMovement moveScript;
        protected Animator anim;
        [SerializeField] protected int healtPoints;
        protected Rigidbody2D rb;
        protected BoxCollider2D coll;
        [SerializeField] protected float knockbackForce;
        [SerializeField] protected LayerMask ground;

        [SerializeField] protected GameObject Player;
        protected Vector2 playerEnnemyDistance;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
          
        }

        

        protected void Damaged() //when ennemy is hit
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

        protected void Knockback() //the ennemy knockback after a hit
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
        
        
        protected bool IsGrounded() // checks if player is on the ground and can jump
        {
            return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, ground);
        }
    }
}