using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class CameraForwardFollower : MonoBehaviour
{
    Transform camara;
    [SerializeField]
    float velocidadGiro = 5f;
    float anguloGiro = 90f;
    public float n = 1f;
    // Start is called before the first frame update
    void Start()
    {
        camara = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        print(Input.GetAxis("L_YAxis_1"));

        Vector3 rotacion = new Vector3(0, Input.GetAxis("L_XAxis_1") * anguloGiro, 0);
        transform.LookAt(new Vector3(camara.position.x, transform.position.y, camara.position.z));
        if (Input.GetAxis("L_YAxis_1") > 0)
        {
            Quaternion rotObjetivo1 = Quaternion.Euler(transform.eulerAngles + rotacion *-1);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotObjetivo1, velocidadGiro);
        }
        else
        {
            Quaternion rotObjetivo2 = Quaternion.Euler(transform.eulerAngles + rotacion);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotObjetivo2, velocidadGiro);
        }
        
    }

}
