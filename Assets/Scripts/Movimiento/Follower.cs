using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform target;
    Vector3 inputs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("L_XAxis_1") * -1;
        float v = Input.GetAxis("L_YAxis_1") * -1;
        inputs = new Vector3(h, 0, v).normalized;

        Vector3 hRight = new Vector3(target.right.x, 0, target.right.z);
        Vector3 hFw = new Vector3(target.forward.x, 0, target.forward.z);
        Vector3 posicionObjetivo = target.position + (inputs.x * -1* hRight + inputs.z * hFw);
        posicionObjetivo.y = target.position.y;

        transform.position = posicionObjetivo;
        //transform.rotation = target.rotation;
    }
}
