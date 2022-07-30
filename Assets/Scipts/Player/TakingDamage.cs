using UnityEngine;
using UnityEngine.UI;

namespace Scipts.Player
{
    public class TakingDamage : MonoBehaviour
    {
        private PlayerMovement moveScript;
        private Animator anim;
        private int healtPoints;
        private Rigidbody2D rb;
        [SerializeField] private Image life1;
        [SerializeField] private Image life2;
        [SerializeField] private Image life3;

        // Start is called before the first frame update
        void Start()
        { 
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            healtPoints = 3;
            moveScript = GetComponent<PlayerMovement>();
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("spike"))
            {
                Damaged();
            }
            else if (collision.gameObject.CompareTag("ennemy"))
            {
                Damaged();
            }
            
        }

        private void Damaged()
        {
            healtPoints -= 1;
            Debug.Log("Hero has "+ healtPoints + " hp");
            
            if (healtPoints == 0) // on death
            {
                anim.SetTrigger("death");
                moveScript.enabled = false;
                rb.mass = 100000;
                
                
                life1.GetComponent<Animator>().SetTrigger("LostLife1");
                

            }
            
            
            anim.SetTrigger("damaged");

            if (healtPoints == 2)
            {
                life3.GetComponent<Animator>().SetTrigger("LostLife3");
            }
            if (healtPoints == 1)
            {
                life2.GetComponent<Animator>().SetTrigger("LostLife2");
            }
        }
    }
}