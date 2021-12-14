using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mole : MonoBehaviour
{
    
    //Show & Hide Variables
    public float visibleYHeight = 0f;
    public float hiddenYHeight = -3.5f;
    private Vector3 myNewXYZPosition;
    public float speed = 4f;
    public float hideMoleTimer = 1.5f;

    //Mole is Created
    void Awake()
    {
        HideMole();

        transform.localPosition = myNewXYZPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, myNewXYZPosition, Time.deltaTime * speed);

        //Timer llega a 0 
        hideMoleTimer -= Time.deltaTime;
        if (hideMoleTimer < 0)
        {           
            HideMole();
        }            

    }

    public void HideMole()
    {
        //Set the current position to hiddenYHeight
        myNewXYZPosition = new Vector3(transform.localPosition.x, hiddenYHeight, transform.localPosition.z);
    }

    public void ShowMole()
    {
        //Set the current position to visibleYHeight
        myNewXYZPosition = new Vector3(transform.localPosition.x, visibleYHeight, transform.localPosition.z);

        hideMoleTimer = 1.5f;
    }


}
