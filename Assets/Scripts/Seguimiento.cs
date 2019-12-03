using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguimiento : MonoBehaviour
{
    public GameObject personaje;
    public Transform direccion;
    ParticleSystem particulas;
    public float velocidadMin = 1f;

    void Start()
    {
        particulas = GetComponent<ParticleSystem>();
        particulas.Pause();
    }


    void Update()
    {
        LanzaParticulas();
        AdaptaParticulas();
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
                                                                          personaje.transform.position.y - 0.5f,
                                                                          personaje.transform.position.z), Time.deltaTime * 40);

        transform.rotation = Quaternion.Euler(direccion.rotation.eulerAngles);    
    }
}
