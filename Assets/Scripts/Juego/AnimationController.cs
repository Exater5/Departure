using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    CharacterController huevo;
    Animation animacion;
    Rigidbody rb;
    bool rodando = false;
    // Start is called before the first frame update
    void Start()
    {
        huevo = GetComponent<CharacterController>();
        animacion = GetComponent<Animation>();
        animacion["PasoABola"].speed *= 1.5f;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (huevo != null)
        {
            ActualizaAnimacion();
        }

        if ((Input.GetAxis("TriggersR_1")) >= 0.5)
        {
            if (!rodando)
            {
                rodando = true;
                StartCoroutine(Rueda());
            }
        }
        else
        {
            rodando = false;
        }
    }

    void ActualizaAnimacion()
    {
        if (!rodando)
        {
            if (huevo.velocity.magnitude >= 0.1)
            {
                animacion.clip = animacion.GetClip("Corriendo");
                animacion["Corriendo"].speed = huevo.velocity.magnitude * 2;
                animacion.Play();
                if (Input.GetAxis("L_YAxis_1") > 0)
                {
                    animacion["Corriendo"].speed = (huevo.velocity.magnitude * 2) * -1;
                }
            }
            else
            {
                animacion.clip = animacion.GetClip("Parado");
                animacion.Play();
            }
        }
    }

    IEnumerator Rueda()
    {
        animacion.clip = animacion.GetClip("PasoABola");
        animacion.Play();
        yield return new WaitForSeconds(1f);
        rb.isKinematic = false;
        huevo.enabled = false;
        yield return null;
    }
}