﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoHuevo : MonoBehaviour
{
    CharacterController huevo;
    public Transform seguidor;
    public float velocidad;
    public float gravedad;
    public float sensibilidad;
    float h;
    float v;
    float peso;
    Vector3 inputs;
    Vector3 camFward;
    Vector3 camRight;
    Vector3 movePlayer;
    AnimationController aC;
    // Start is called before the first frame update
    void Start()
    {
        huevo = GetComponent<CharacterController>();
        aC = GetComponent<AnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("L_XAxis_1") *-1;
        v = Input.GetAxis("L_YAxis_1") *-1;
        inputs = new Vector3(h,0,v);
        Vector3 posicionObjetivo = (h * -1 * transform.right + v * transform.forward);
        movePlayer = (posicionObjetivo * velocidad);
        SetGravity();
        movePlayer.y = peso;

    }
    private void FixedUpdate()
    {
        if (!aC.rodando)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - h * sensibilidad, transform.rotation.eulerAngles.z);
            huevo.Move(movePlayer / 100);
        }

    }

    void SetGravity()
    {
        if (huevo.isGrounded)
        {
            peso = -gravedad * Time.deltaTime;
        }
        else
        {
            peso -= gravedad * Time.deltaTime;
        }
    }
}
