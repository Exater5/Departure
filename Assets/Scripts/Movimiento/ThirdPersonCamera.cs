using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform lookAt;

    public const float yMinAngle = 8;
    public const float yMaxAngle = 65f;
    public float sensibilidadHorizontal = 1f;
    public float sensibilidadVertical = 1f;
    public float distance = 10f;
    float currentX;
    float currentY;
    float x;
    float y;
    float initialx;
    float initialy;

    Vector3 distancia;
    Quaternion rotacionCamara;
    Quaternion rotacionHuevo;
    Quaternion encuadre;

    bool cuadrando = false;
    bool girando = false;
    bool puedeGirar = false;
    void Start()
    {
        distancia = new Vector3(0, 0, -distance);
        rotacionCamara = Quaternion.Euler(25, lookAt.rotation.eulerAngles.y, 0);
        transform.position = lookAt.position + rotacionCamara * distancia;
        transform.LookAt(lookAt);
        currentX = 0;
        currentY = 25;
    }

    private void Update()
    {
        x = Input.GetAxis("R_XAxis_0");
        y = Input.GetAxis("R_YAxis_0");
        currentX += (x * sensibilidadHorizontal);
        currentY += (y * sensibilidadVertical);
        currentY = Mathf.Clamp(currentY, yMinAngle, yMaxAngle);
        Rotador();
    }

    void Rotador()
    {
        if(x + y != 0)
        {
            if (puedeGirar)
            {
                if (!girando)
                {
                    initialx = -lookAt.rotation.eulerAngles.z;
                    initialy = lookAt.rotation.eulerAngles.y;
                    girando = true;
                }
                rotacionCamara = Quaternion.Euler(currentY - initialx, currentX + initialy, 0);
                transform.position = lookAt.position + rotacionCamara * distancia;
                transform.LookAt(lookAt);
            }
        }
        else
        {
            girando = false;
            if (currentX + currentY != 25)
            {
                if (!cuadrando)
                {
                    puedeGirar = false;
                    StartCoroutine(Cuadra());
                    cuadrando = true;
                }
            }
            else
            {
                encuadre = Quaternion.Euler(25, lookAt.rotation.eulerAngles.y, 0);
                transform.position = lookAt.position + encuadre * distancia;
                transform.LookAt(lookAt);
                puedeGirar = true;
            }
        }
    }
    IEnumerator Cuadra()
    {
        float duracion = 1f;
        for (float i = 0; i <= duracion; i+= Time.deltaTime)
        {
            encuadre = Quaternion.Lerp(Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0), Quaternion.Euler(25, lookAt.rotation.eulerAngles.y, 0), i/duracion);
            transform.position = lookAt.position + encuadre * distancia;
            transform.LookAt(lookAt);
            yield return null;
        }
        encuadre = Quaternion.Euler(25, lookAt.rotation.eulerAngles.y, 0);
        currentX = 0;
        currentY = 25;
        cuadrando = false;
        puedeGirar = true;
    }
}
