﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTobogan : MonoBehaviour
{
    public PhysicMaterial toboMaterial;
    PhysicMaterial startMaterial;
    GameObject gSeguimiento;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.transform.CompareTag("Player"))
        {
            col.GetComponent<MovimientoLibre>().enabled = false;
            startMaterial = col.GetComponent<CapsuleCollider>().material;
            col.GetComponent<CapsuleCollider>().material = toboMaterial;
        }
        gSeguimiento = FindObjectOfType<SeguimientoParticulas>().gameObject;
        gSeguimiento.SetActive(false);
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.transform.CompareTag("Player"))
        {
            col.GetComponent<MovimientoLibre>().enabled = true;
            col.GetComponent<CapsuleCollider>().material = startMaterial;
        }
        gSeguimiento.SetActive(true);
    }
}
