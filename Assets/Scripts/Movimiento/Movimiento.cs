using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Rigidbody rb;
    public float velocidad = 1;
    public float velocidadMaxima = 10;
    public Transform direccion;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        print(transform.forward);
        float vertical = Input.GetAxis("L_YAxis_1");
        float horizontal = Input.GetAxis("L_XAxis_1");

        if (rb.velocity.magnitude < velocidadMaxima)
        {
            rb.AddForce(direccion.forward.normalized * vertical * velocidad);
            rb.AddForce(direccion.right.normalized * horizontal * velocidad);
        }

    }
}
