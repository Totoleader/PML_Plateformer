using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scipts.Collectables
{
    public class CointCounter : MonoBehaviour
    {

        public static int NumberOfCoin;
        private Text coins;
        // Start is called before the first frame update
        void Start()
        {
            coins = GetComponent<Text>();
            NumberOfCoin = 0;
        }

        // Update is called once per frame
        void Update()
        {
           coins.text = "X " + NumberOfCoin;
        }
    
    
    }
}
