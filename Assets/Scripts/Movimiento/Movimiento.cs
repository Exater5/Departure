using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Rigidbody rb;
    public float velocidad;
    public float velocidadMaxima;
    public Transform direccion;
    float vertical;
    float horizontal;
    Vector3 rotacionObjetivo;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rotacionObjetivo = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        transform.LookAt(rotacionObjetivo);
    }
    void FixedUpdate()
    {
        if (rb.velocity.magnitude < velocidadMaxima)
        {
            float vertical = Input.GetAxis("L_YAxis_1");
            float horizontal = Input.GetAxis("L_XAxis_1");
            rb.AddForce(transform.forward * vertical * velocidad);
            rb.AddForce(transform.right * horizontal * velocidad * -1);
        }
    }
}
