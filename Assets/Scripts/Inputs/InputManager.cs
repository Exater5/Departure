using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Boton boton;
    Vector3 posInicio;
    public class Boton
    {
        public bool pulsado;
        public bool activado;
    }



    void Start()
    {
        posInicio = transform.position;
    }

    

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.position = new Vector3 (posInicio.x * h,transform.position.y, transform.position.z).normalized;
        transform.position = new Vector3(transform.position.x, posInicio.y * v, transform.position.z).normalized;
        Debug.Log(h);
    }
}
