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

    void Start()
    {
        cam = Camera.main;
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
    }

    void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(-currentY, currentX, 0);
        transform.position = lookAt.position + rotation * dir;
        transform.LookAt(lookAt);
    }

}
