using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public float velocidad;
    Animation animacion;
    public Rigidbody rbHuevo;
    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        velocidad = rbHuevo.velocity.magnitude * 200000;
        if (velocidad >= 1)
        {
            animacion.clip = animacion.GetClip("Corriendo");
            animacion["Corriendo"].speed = velocidad;
            animacion.Play();
        }
        else
        {
            animacion.clip = animacion.GetClip("Parado");
            animacion.Play();
        }
    }
}
