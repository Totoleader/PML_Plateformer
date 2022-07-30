using System;
using UnityEngine;

namespace Scipts.Ennemies.Bat
{
    public class BatMovement : MonoBehaviour
    {
        private Rigidbody2D rb;
        [SerializeField] private GameObject Player;

        [SerializeField] private float speed;
        private SpriteRenderer sprite;
        [SerializeField] private float aggroDistance;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            sprite = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            Movement();
        }

        private void Movement()
        {
            var batPositionX = transform.position.x;
            var playerPositionX = Player.transform.position.x;
            var batPositionY = transform.position.y;
            var playerPositionY = Player.transform.position.y;


            if (Math.Abs(playerPositionX - batPositionX) < aggroDistance) //enemy starts moving when at a certain distance of player
            {
                var playerPosition = Player.transform.position;
                var ennemyPosition = transform.position;
                var playerEnnemyDistanceX = playerPosition.x - ennemyPosition.x;
                var playerEnnemyDistanceY = playerPosition.y + 2 - ennemyPosition.y;
                double normeDistance;
                Vector2 vecteurUnitaire;


                var playerEnnemyDistance = new Vector2(playerEnnemyDistanceX, playerEnnemyDistanceY);

                normeDistance =
                    Math.Sqrt(Math.Pow(playerEnnemyDistanceX, 2) + Math.Pow(playerEnnemyDistanceY, 2)); //norme

                vecteurUnitaire =
                    playerEnnemyDistance / (float)normeDistance; //vecteur unitaire (direction) entre player et ennemy

                rb.velocity = vecteurUnitaire * speed;

                
                //flips sprite depending on the way the bat is going
                if (playerPosition.x > ennemyPosition.x)
                {
                    sprite.flipX = false;
                }
                else if (playerPosition.x < ennemyPosition.x)
                {
                    sprite.flipX = true;
                }
            }
        }
        
        
    }
}