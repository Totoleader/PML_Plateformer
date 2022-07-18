using UnityEngine;

namespace Scipts.Player
{
    public class TakingDamage : MonoBehaviour
    {
        private Animator anim;
        
       

        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
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
        }

        private void Damaged()
        {
            anim.SetTrigger("damaged");
        }
    }
}
