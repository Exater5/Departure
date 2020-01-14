using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform lookAt;
    Camera cam;
    public const float yMinAngle = -50f;
    public const float yMaxAngle = 20f;
    public float sensibilidadHorizontal = 1f;
    public float sensibilidadVertical = 1f;
    public float distance = 10f;
    float currentX;
    float currentY;
    public float duracionCuadra;
    Vector3 distancia;
    Coroutine cr;
    Quaternion rotacionCamara;
    Quaternion rotacionHuevo;
    void Start()
    {
        cam = Camera.main;
        distancia = new Vector3(0, 0, -distance);
    }

    private void Update()
    {
        float x = Input.GetAxis("R_XAxis_0");
        float y = Input.GetAxis("R_YAxis_0");
        currentX += x * sensibilidadHorizontal;
        currentY += y * sensibilidadVertical;
        currentY = Mathf.Clamp(currentY, yMinAngle, yMaxAngle);
        Rotador(new Vector2(currentX, currentY), x + y);
    }

    void Rotador(Vector2 rot, float magnitud)
    {
        if(magnitud != 0)
        {
            if (cr != null)
            {
                StopCoroutine(cr);
            }
            rotacionCamara = Quaternion.Euler(-rot.y + 25, rot.x + lookAt.rotation.eulerAngles.y, 0);
            transform.position = lookAt.position + rotacionCamara * distancia;
            transform.LookAt(lookAt);


        }
        else
        {
            if(rotacionCamara != rotacionHuevo)
            {
                //cr = StartCoroutine(Cuadra());
            }
            Quaternion rotacionObjetivo = Quaternion.Euler(25, lookAt.rotation.eulerAngles.y, 0);
            transform.position = lookAt.position + rotacionObjetivo * distancia;
            transform.LookAt(lookAt);
            currentX = 0;
            currentY = 0;
        }
    }
    IEnumerator Cuadra()
    {
        Quaternion rotacionObjetivo;

        float duracion = 0.75f;
        for(float i = 0; i <= duracion; i+= Time.deltaTime)
        {
            rotacionHuevo = Quaternion.Euler(25, lookAt.rotation.eulerAngles.y * (i/duracion), 0);
            rotacionObjetivo = Quaternion.Lerp(rotacionCamara, rotacionHuevo, duracion/i);
            transform.position = lookAt.position + rotacionObjetivo * distancia;
            transform.LookAt(lookAt);
            yield return null;
        }
        rotacionObjetivo = Quaternion.Euler(25, lookAt.rotation.eulerAngles.y, 0);
        transform.position = lookAt.position + rotacionObjetivo * distancia;
        transform.LookAt(lookAt);
    }
}
