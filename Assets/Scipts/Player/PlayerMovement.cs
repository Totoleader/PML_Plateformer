using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float LeftRightInput;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //left-right movement
       LeftRightInput = Input.GetAxis("Horizontal");    
       GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed * LeftRightInput, GetComponent<Rigidbody2D> ().velocity.y);
       
       //jump
       
    }
}
