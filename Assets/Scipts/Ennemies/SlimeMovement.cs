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
          
        movement();
        }

        private void movement()
        {
            var transformPosition = transform.position;
            
            if (Math.Abs(Player.transform.position.x - transformPosition.x) < 9)
            {
                
            
                if (Player.transform.position.x > transformPosition.x)
                {
                    rb.velocity = Vector2.right * speed;
                }
                else if (Player.transform.position.x < transformPosition.x)
                {
                    rb.velocity = Vector2.left * speed;
                }
            
            }
        }
    }
}
