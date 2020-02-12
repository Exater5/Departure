using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    CharacterController huevo;
    Animation animacion;
    Rigidbody rb;
    public bool rodando = false;
    bool reactivaColliders = false;
    [SerializeField]
    Transform huevoCollider;
    RotationController rController;
    [SerializeField]
    float duracionRotacion;
    [SerializeField]
    AnimationCurve ac;
    Quaternion rotInicial;
    public GameObject particulas;
    // Start is called before the first frame update
    void Start()
    {
        huevo = GetComponent<CharacterController>();
        animacion = GetComponent<Animation>();
        rb = GetComponent<Rigidbody>();
        rController = FindObjectOfType<RotationController>().GetComponent<RotationController>();
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
                Rueda();
            }
        }
        else
        {
            if (rodando)
            {
                rodando = false;
                TerminaDeRodar();
            }
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

    public void Rueda()
    {
        rotInicial = transform.rotation;
        animacion.clip = animacion.GetClip("Rueda");
        animacion.Play();
        Camera.main.GetComponent<ThirdPersonCamera>().lookAt = huevoCollider;
    }
    public void AjusteRueda()
    {
        rb.isKinematic = false;
        huevo.enabled = false;
        rController.rodando = true;
        reactivaColliders = false;
    }
    public void TerminaDeRodar()
    {
        rController.rodando = false;
        transform.rotation = rotInicial;
        Instantiate(particulas, transform.position, Quaternion.identity);
        animacion.clip = animacion.GetClip("Parado");
        animacion.Play();

        Camera.main.GetComponent<ThirdPersonCamera>().lookAt = transform;
        rb.isKinematic = true;
        huevo.enabled = true;
        reactivaColliders = true;
    }
}