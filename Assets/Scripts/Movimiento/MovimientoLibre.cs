using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class MovimientoLibre : MonoBehaviour
{
    public float velocidad;
    float velocidadRb;
    float vertical;
    float horizontal;
    bool rodando = false;
    Rigidbody rb;

    //Animaciones
    Animation animacion;
    bool haciaAlante;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animacion = GetComponent<Animation>();
    }
    private void Update()
    {
        vertical = Input.GetAxis("L_YAxis_1");
        horizontal = Input.GetAxis("L_XAxis_1");
        transform.Translate(new Vector3(-horizontal, 0, vertical) * velocidad/100);

        for (int i = 0; i < 5; i++)
            ObtieneInput((GamePad.Index)i);

        //Animaciones
        velocidadRb = velocidad/10 + rb.velocity.magnitude * 200000;
        if (velocidadRb >= 0.1f)
        {
            animacion.clip = animacion.GetClip("Corriendo");
            animacion["Corriendo"].speed = velocidadRb / 1.2f;
            animacion.Play();
            if (vertical < 0)
            {
                animacion["Corriendo"].speed = Mathf.Abs(animacion["Corriendo"].speed);
            }
            else
            {
                animacion["Corriendo"].speed *= -1;
            }
        }
        else
        {
            animacion.clip = animacion.GetClip("Parado");
            animacion.Play();
        }
    }
    public void ObtieneInput(GamePad.Index controller)
    {
        GamepadState boton = GamePad.GetState(controller);
        if ((boton.RightTrigger) >= 0.5 && !rodando)
        {
            print("Activo Habilidad");
            rodando = true;
            StartCoroutine(Rueda());
        }
        transform.Rotate(new Vector3(0, boton.LeftStickAxis.x * 90, 0)*Time.deltaTime);
    }
    IEnumerator Rueda()
    {
        animacion.clip = animacion.GetClip("PasoABola");
        animacion.Play();
        yield return new WaitForSeconds(1);
        print("Ya he rodado");
        rodando = false;
    }
}
