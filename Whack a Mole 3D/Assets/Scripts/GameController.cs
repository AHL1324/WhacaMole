using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //timer Variables
    public TextMesh timerText;
    public float gameTimer = 30f; //tiempo de juego

    //Mole Variables
    public GameObject moleContainer;
    private Mole[] moles;
    public float showMoleTimer = 1.5f;


    //Restart variables
    [SerializeField]
    private TextMesh restartText;

   

    // Start is called before the first frame update
    void Start()
    {
        moles = moleContainer.GetComponentsInChildren<Mole>();

        restartText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;

        //Timer mayor que O

        if(gameTimer > 0f)
        {
            timerText.text = "Whack a Mole: " + Mathf.Floor(gameTimer); //Mathf.Floor para quitar los milisegundos
            showMoleTimer -= Time.deltaTime;
            if(showMoleTimer > 0f)
            {
                moles[Random.Range(0, moles.Length)].ShowMole();

                showMoleTimer = 1.5f;
            }
        }

       
        //Timer menos que 0 reset
        else
        {
            timerText.text = "GAME OVER";

            //Show restart text
            restartText.gameObject.SetActive(true);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                RestartGame();
            }
        }
        
    }
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
