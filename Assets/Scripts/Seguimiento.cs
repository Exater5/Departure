using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguimiento : MonoBehaviour
{
    public GameObject personaje;
    public Transform direccion;
    ParticleSystem particulas;
    public float velocidadMin = 1f;
    public float altura = 0.5f;
    bool activada = false;

    void Update()
    {
        AdaptaParticulas();
        if (!activada)
        {
            CompruebaParticulas();
        }
        else
        {
            LanzaParticulas();        
        }
    }

    void CompruebaParticulas()
    {
        if (personaje.GetComponent<Rigidbody>().velocity.magnitude > velocidadMin)
        {
            if (!activada)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                particulas = transform.GetChild(0).GetComponent<ParticleSystem>();
                activada = true;
            }
        }
    }
    void LanzaParticulas()
    {
        if (personaje.GetComponent<Rigidbody>().velocity.magnitude > velocidadMin)
        {
            particulas.loop = true;
            particulas.Play();
        }
        else
        {
            particulas.loop = false;
        }
    }
    void AdaptaParticulas()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(personaje.transform.position.x,
                                                                          personaje.transform.position.y - altura,
                                                                          personaje.transform.position.z), Time.deltaTime * 40);
        transform.rotation = Quaternion.Euler(direccion.rotation.eulerAngles);    
    }
}
