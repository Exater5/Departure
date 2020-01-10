using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform lookAt;
    Camera cam;
    public const float yMinAngle = -50f;
    public const float yMaxAngle = 0f;
    public float sensibilidadHorizontal = 1f;
    public float sensibilidadVertical = 1f;
    public float distance = 10f;
    float currentX;
    float currentY;
    bool cuadrando = false;
    public float duracionCuadra;
    bool empieza = false;
    Vector3 dir;
    void Start()
    {
        cam = Camera.main;
        dir = new Vector3(0, 0, -distance);
    }

    private void Update()
    {
        for (int i = 0; i < 5; i++)
            ObtieneInputs((GamePad.Index)i);
    }

    public void ObtieneInputs(GamePad.Index controller)
    {
        GamepadState state = GamePad.GetState(controller);

        currentX += state.rightStickAxis.x * sensibilidadHorizontal;
        currentY += state.rightStickAxis.y * sensibilidadVertical;
        currentY = Mathf.Clamp(currentY, yMinAngle, yMaxAngle);

        /*
        if(state.RightShoulder == true && !cuadrando)
        {
            print("Cuadro");
            cuadrando = true;
        }
        */
    }

    void LateUpdate()
    {
        Quaternion rotation;
        if (!cuadrando)
        {
            rotation = Quaternion.Euler(-currentY, currentX, 0) ;
            transform.position = lookAt.position + rotation  * dir;
            if (!empieza)
            {
                empieza = true;
            }
        }
        else
        {
            Quaternion rotacionHuevo = Quaternion.Euler(0, -lookAt.rotation.y * 360, 0);
            transform.position = lookAt.position + rotacionHuevo * dir;
            cuadrando = false;
            // StartCoroutine(Cuadra());
        }
        transform.LookAt(lookAt);
    }
    IEnumerator Cuadra()
    {
        for (float i = 0; i<duracionCuadra; i += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position, duracionCuadra/i );
            yield return null;
        }
        cuadrando = false;
    }
}
