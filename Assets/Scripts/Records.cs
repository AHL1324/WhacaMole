using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Records : MonoBehaviour
{          
    public TextMesh scoreText;
    private int score;

    public TextMesh recordText;    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        recordText.text = PlayerPrefs.GetInt("Record", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Record()
    {        
        scoreText.text = "SCORE:" + score;

        if(score > PlayerPrefs.GetInt("Record", 0))
        {
            PlayerPrefs.SetInt("Record", score);
            recordText.text = score.ToString();
        }
    }
}
