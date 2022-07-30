using System;
using Scipts.Ennemies;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scipts.Collectables
{
    public class CoinController : MonoBehaviour
    {
        private Rigidbody2D rb;
        private GameObject player;
        private Collider coll;

        [SerializeField] private float magnetRange;
        [SerializeField] private float magnetForce;
        //[SerializeField] private float rotateSpeed;

        private float Ximpulse;

        // Start is called before the first frame update
        void Start()
        {
            coll = GetComponent<Collider>();
            rb = GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(RandomX(), RandomY()) * 5, ForceMode2D.Impulse);
            
            player = GameObject.FindWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
            MagnetToPlayer();
        }

        private float RandomX()
        {
            return Random.Range(-.5f, .5f);
        }

        private float RandomY()
        {
            return Random.Range(.5f, 1.5f);
        }

        private void MagnetToPlayer()
        {
            var playerPosition = player.transform.position;
            var ennemyPosition = transform.position;
            var playerEnnemyDistanceX = playerPosition.x - ennemyPosition.x;
            var playerEnnemyDistanceY = playerPosition.y - ennemyPosition.y;
            double normeDistance;
            Vector2 vecteurUnitaire;
            var playerEnnemyDistance = new Vector2(playerEnnemyDistanceX, playerEnnemyDistanceY);
            
            if (Math.Abs(ennemyPosition.x - playerPosition.x) < magnetRange)
            {
                Debug.Log("methode appelée");
                normeDistance =
                    Math.Sqrt(Math.Pow(playerEnnemyDistanceX, 2) + Math.Pow(playerEnnemyDistanceY, 2)); //norme

                vecteurUnitaire =
                    playerEnnemyDistance / (float)normeDistance; //vecteur unitaire (direction) entre player et ennemy

                rb.AddForce(vecteurUnitaire * magnetForce / (float) Math.Pow(normeDistance, 2),ForceMode2D.Force);
                
            }
        }
    }
}