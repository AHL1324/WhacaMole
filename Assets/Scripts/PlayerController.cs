using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    //Variables
    private float horizontalInput;
    private float verticalInput;
    [SerializeField]
    private float speed = 12f;
 
    
    // Update is called once per frame
    void Update()
    {
        //Set Input Axis
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Move when user presses the arrow keys
        transform.Translate(-Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(-Vector3.forward * verticalInput * Time.deltaTime * speed);
    }
}
