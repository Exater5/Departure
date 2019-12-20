using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraForwardFollower : MonoBehaviour
{
    Transform camara;
    // Start is called before the first frame update
    void Start()
    {
        camara = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 cameraTargetPosition = new Vector3(camara.position.x * -1, transform.position.y, camara.position.z * -1);
        transform.LookAt(new Vector3(camara.position.x, transform.position.y, camara.position.z));
    }
}
