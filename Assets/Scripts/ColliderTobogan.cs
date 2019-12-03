using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTobogan : MonoBehaviour
{
    public PhysicMaterial toboMaterial;
    public PhysicMaterial startMaterial;
    
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
            col.GetComponent<Movimiento>().enabled = false;
            startMaterial = col.GetComponent<CapsuleCollider>().material;
            col.GetComponent<CapsuleCollider>().material = toboMaterial;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.transform.CompareTag("Player"))
        {
            col.GetComponent<Movimiento>().enabled = true;
            col.GetComponent<CapsuleCollider>().material = startMaterial;
        }
    }
}
