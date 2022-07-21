using System;
using UnityEngine;

namespace Scipts.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        private SpriteRenderer playerSprite;
        private BoxCollider2D attackHitBox;
        private Animator anim;
        private float nextAttackAllowed;
        private float offsetX;

        [SerializeField] private float attackOneCooldown;

        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponentInParent<Animator>();
            nextAttackAllowed = 0;
            attackHitBox = GetComponent<BoxCollider2D>();
            playerSprite = GetComponentInParent<SpriteRenderer>();
            offsetX = attackHitBox.offset.x;
        }

        // Update is called once per frame
        void Update()
        {
            AttackUpdate();
        }

        void AttackUpdate()
        {
            var hitBoxOffset = attackHitBox.offset; //**put the 3 lines in the "if" below with attack input to make the hitbox not change direction during attack
            hitBoxOffset = new Vector2(offsetX, hitBoxOffset.y);//changes the direction of the attack hitbox depending on the way the player is facing
            attackHitBox.offset = hitBoxOffset;
            if (playerSprite.flipX)
            {
                hitBoxOffset = new Vector2(-hitBoxOffset.x, hitBoxOffset.y);
                attackHitBox.offset = hitBoxOffset;
            }
            
            
            if (Input.GetKeyDown(KeyCode.G) && Time.time > nextAttackAllowed) //Launch attack when player press G
            {
                attackHitBox.enabled = true;
                
                anim.SetTrigger("attackOne");   
                nextAttackAllowed = Time.time + attackOneCooldown;
            }

            if (Time.time > nextAttackAllowed - .15f) //temps ou la hitbox d'attaque est active
            {
                attackHitBox.enabled = false;
            }
        }
    }
}