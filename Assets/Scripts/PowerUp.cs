using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject powerup;
    private float tiempoCreacion = 20f;
    private float RangoCreacion = 4f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawner", 0.0f, tiempoCreacion);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawner()
    {
        float posXGeneracion = Random.Range(-RangoCreacion, RangoCreacion);
        float posZGeneracion = Random.Range(-RangoCreacion, RangoCreacion);

        Vector3 posAleatoria = new Vector3(posXGeneracion, 3, posZGeneracion);
        Instantiate(powerup, posAleatoria, powerup.transform.rotation);

    }    
}