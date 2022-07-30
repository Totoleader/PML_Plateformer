using System;
using UnityEngine;

namespace Scipts.Collectables
{
    public class CoinCollected : MonoBehaviour
    {
        private void Start()
        {
          
        }

        private void OnTriggerEnter2D(Collider2D col) //when ennemy gets hit by player
        {
            if (col.gameObject.CompareTag("Player"))
            {
                Destroy(transform.parent.gameObject);
                CointCounter.NumberOfCoin += 1;
                
            }
        }
    }
}
