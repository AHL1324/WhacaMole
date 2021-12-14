using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    //Variables
    private bool hammerIsUp = true;
    private float hammerDownAngle = 0;
    private float hammerUpAngle = 90;
    private Quaternion hammerDownRotation; //X Angle(0) when hammer is down
    private Quaternion hammerUpRotation; //X Angle(90) when hammer is up
    private float hammerDownMaxTime = 0.25f; //Tiempo que está abajo


    private int score = 0;
    [SerializeField]
    private TextMesh scoreText;
    // Start is called before the first frame update
    void Start()
    {
        hammerDownRotation = Quaternion.Euler(hammerDownAngle, transform.rotation.y, transform.rotation.z);
        hammerUpRotation = Quaternion.Euler(hammerUpAngle, transform.rotation.y, transform.rotation.z);

        //Reset score
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Presionando Space bar, swing the hammer
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //If Hammer is Up, cambiar Hammer with hammerRotation is Down
            if(hammerIsUp)
            {
                SwingHammer(hammerUp:false, hammerRotation:hammerDownRotation);
            }
            //If Hammer is Down, cambiar Hammer with hammerRotation is Up
            else
            {
                SwingHammer(hammerUp: true, hammerRotation: hammerUpRotation);
            }
        }

        //Max tiempo tener el martillo Down of 1/4 seconds
        if(!hammerIsUp)
        {
            hammerDownMaxTime -= Time.deltaTime;
            if(hammerDownMaxTime <= 0f)
            {
                SwingHammer(hammerUp: true, hammerRotation: hammerUpRotation);
            }

        }


    }

    void SwingHammer(bool hammerUp, Quaternion hammerRotation)
    {
        hammerIsUp = hammerUp;

        //Update hammer rotation
        transform.rotation = hammerRotation;


        //Reset hammer max time
        if(hammerIsUp)
        {
            hammerDownMaxTime = 0.25f;
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        //Get Mole I hit uing the tag "Mole"
        if (collision.gameObject.tag == "Mole")
        {
            //Debug.Log("HIT A MOLE");
            UpdateScore();
            
        }
    }

    //UpdateScore
    void UpdateScore()
    {
        score++;
        scoreText.text = "SCORE:" + score;
    }
}
