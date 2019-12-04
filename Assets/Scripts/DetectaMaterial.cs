using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectaMaterial : MonoBehaviour
{
    public LayerMask lMask;
    public GameObject particulas;
    public float distanciaRay;
    RaycastHit hit;
    void Start()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, distanciaRay, lMask))
        {
            particulas.GetComponent<Renderer>().material = hit.transform.gameObject.GetComponent<Renderer>().material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position - new Vector3(0, distanciaRay, 0), Color.yellow, Mathf.Infinity);
        if (Physics.Raycast(transform.position, Vector3.down, out hit, distanciaRay, lMask))
        {
            particulas.GetComponent<Renderer>().material = hit.transform.gameObject.GetComponent<Renderer>().material;
        }
    }
}
