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

    void FixedUpdate()
    {
        if (rb.velocity.magnitude < velocidadMaxima)
        {
            rb.AddForce(new Vector3(0, 0, (Input.GetAxis("Horizontal") * -velocidad * Camera.main.transform.forward.z / Time.deltaTime)));
            rb.AddForce(new Vector3((Input.GetAxis("Vertical") * velocidad * Camera.main.transform.forward.x/ Time.deltaTime), 0, 0));

        }
      
    }
}
