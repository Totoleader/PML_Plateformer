using System;
using UnityEngine;

namespace Scipts.Ennemies
{
    public class SlimeMovement : MonoBehaviour
    {
        private Rigidbody2D rb;
        [SerializeField] private GameObject Player;

        [SerializeField] private float speed;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            Movement();
        }

        private void Movement()
        {
            var slimePosition = transform.position.x;
            var playerPosition = Player.transform.position.x;


            if (Math.Abs(playerPosition - slimePosition) < 9) //enemy starts moving when at a certain distance of player
            {
                if (playerPosition > slimePosition) //moves right if player is to the right
                {
                    rb.velocity = Vector2.right * speed;
                    
                }
                else if (playerPosition < slimePosition) //moves left if player is to the left
                {
                    rb.velocity = Vector2.left * speed;
                }
            }
        }
    }
}