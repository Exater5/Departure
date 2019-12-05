using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaDajno : MonoBehaviour
{
    public LayerMask lMask;
    RaycastHit hit;
    bool wasted = false;
    [SerializeField]
    float minCaida = 0.5f;
    [SerializeField]
    GameObject huevoRoto;
    [SerializeField]
    GameObject controlaParticulas;

    private void OnCollisionExit(Collision collision)
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, lMask))
        {
            if(hit.distance > minCaida)
            {
                wasted = true;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (wasted)
        {
            Instantiate(huevoRoto, transform.position, Quaternion.identity);
            Destroy(controlaParticulas);
            Destroy(gameObject);
        }
    }
}
