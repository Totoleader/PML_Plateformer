using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = System.Random;

namespace Scipts.Ennemies
{
    public abstract class EnnemyTakingDamage : MonoBehaviour //classes "TakingDamage" of ennemies inherit of this class
    {
        
        protected Animator anim;
        [SerializeField] protected int healtPoints;
        protected Rigidbody2D rb;
        protected BoxCollider2D coll;
        [SerializeField] protected float knockbackForce;
        [SerializeField] protected LayerMask ground;

        [SerializeField] protected float knockbackTime;

        [SerializeField] protected Transform Player;
        protected Vector2 playerEnnemyDistance;

        [SerializeField] protected GameObject coin;

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
            var playerEnnemyDistanceY = ennemyPosition.y - playerPosition.y ;
            double normeDistance;
            Vector2 vecteurUnitaire;

            if (healtPoints > 0)
            {
                playerEnnemyDistance =
                    new Vector2(playerEnnemyDistanceX, playerEnnemyDistanceY); //coordonées distance

                normeDistance = Math.Sqrt(Math.Pow(playerEnnemyDistanceX, 2) + Math.Pow(playerEnnemyDistanceY, 2)); //norme

                vecteurUnitaire = playerEnnemyDistance / (float)normeDistance; //vecteur unitaire (direction) entre player et ennemy

                rb.AddForce(vecteurUnitaire * knockbackForce, ForceMode2D.Impulse); 
            }

            StartCoroutine(UnKnockback());
        }
        
        
        protected bool IsGrounded() // checks if player is on the ground and can jump
        {
            return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, ground);
        }

        protected IEnumerator UnKnockback()
        {
            yield return new WaitForSeconds(knockbackTime);
            EnableMovescipt();
        }

        protected virtual void EnableMovescipt()
        {
           
        }
            
        protected void DropLoot()
        {
            for (int i = 0; i < ExtraLoot(); i++)
            {
                Instantiate(coin, transform.position, Quaternion.identity);
            }
            
        }
        
        private int ExtraLoot()
        {
            return (int) UnityEngine.Random.Range(0, 2.5f) + 1;
        }

        
    }
    
    
}