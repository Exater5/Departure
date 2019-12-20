using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class InputManager : MonoBehaviour
{
    Rigidbody rb;
    Vector3 posInicio;
    [SerializeField]
    float velocidad = 2f;
    public float velocidadMaxima = 10;
    public Vector2 joystickDerecho;
    Transform camara;
    [SerializeField]
    Transform seguidor;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posInicio = transform.position;
        camara = Camera.main.transform;
    }
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < 5; i++)
            ObtieneInputs((GamePad.Index)i);
    }
    public void ObtieneInputs(GamePad.Index controller)
    {
        GamepadState state = GamePad.GetState(controller);

        Vector3 direccion = new Vector3(seguidor.forward.x * -1, 0 , seguidor.forward.z * -1);

        //Vector3 movimientoZ = new Vector3(state.LeftStickAxis.x, 0, state.LeftStickAxis.y);
        float axisAdelante = state.LeftStickAxis.y;
        float axisLados = state.LeftStickAxis.x;
        if (rb.velocity.magnitude < velocidadMaxima)
        {
            rb.AddForce(direccion.normalized * axisAdelante * velocidad);
        }

    }
}
