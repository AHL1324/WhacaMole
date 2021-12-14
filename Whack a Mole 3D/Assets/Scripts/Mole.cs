using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public float visibleYHeight = 3.0f;
    public float hiddenYHeight = -3.0f;
    private Vector3 myNewXYZPosition;
    public float speed = 4f;
    public float hideMoleTimer = 1.5f;  


    //Mole is created
    void Awake()
    {
        HideMole();
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hideMoleTimer -= Time.deltaTime;
        transform.localPosition = Vector3.Lerp(transform.localPosition, myNewXYZPosition, hideMoleTimer);
      

        if (transform.localPosition == myNewXYZPosition)
        {
            HideMole();
        }

    }

    public void HideMole()
    {
        hideMoleTimer = 0f;

        //Set the current position to hiddenYHeight
        myNewXYZPosition = new Vector3(transform.localPosition.x, hiddenYHeight, transform.localPosition.z);            

    }

    public void ShowMole()
    {
        //Reset the hideMoleTimer to 1.5 seconds before hiding
        hideMoleTimer = 1.5f;

        //Set the current position to visibleYHeight
        myNewXYZPosition = new Vector3(transform.localPosition.x, visibleYHeight, transform.localPosition.z);

        



    }


}
