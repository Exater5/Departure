using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public bool rodando = false;
    public float rotacionAntesDeRodar;
    public Transform huevoRodando;
    void Update()
    {
        if (!rodando)
        {
            rotacionAntesDeRodar = huevoRodando.parent.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, rotacionAntesDeRodar, 0);
        }
        else
        {
            transform.rotation = transform.rotation;
        }

        transform.position = huevoRodando.position;
    }
}
