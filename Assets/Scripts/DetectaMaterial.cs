using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectaMaterial : MonoBehaviour
{
    public LayerMask lMask;
    public GameObject particulas;
    RaycastHit hit;
    void Start()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 6f, lMask))
        {
            particulas.GetComponent<Renderer>().material = hit.transform.gameObject.GetComponent<Renderer>().material;
        }
    }

    // Update is called once per frame
    void Update()
    {       
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 6f, lMask))
        {
            particulas.GetComponent<Renderer>().material = hit.transform.gameObject.GetComponent<Renderer>().material;
        }
    }
}
