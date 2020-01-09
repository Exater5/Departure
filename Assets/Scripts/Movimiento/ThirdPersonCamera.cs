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

      /*  if(state.RightShoulder == true && !cuadrando)
        {
            cuadrando = true;

        }
        */
    }

    void LateUpdate()
    {
        Quaternion rotation;
        if (!cuadrando)
        {
            rotation = Quaternion.Euler(-currentY, currentX, 0);
            transform.position = lookAt.position + rotation * dir;
        }
        else
        {
            StartCoroutine(Cuadra());
        }
        transform.LookAt(lookAt);
    }
    IEnumerator Cuadra()
    {
        for(float i = 0; i<0.75f; i += Time.deltaTime)
        {
            transform.position = lookAt.position + new Quaternion(0,0,0,0)* dir/0.75f;
            yield return null;
        }
        cuadrando = false;
    }
}
