using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaGiros : MonoBehaviour
{
    public int[] giroPiezas;
    public int[] girosNecesarios;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(giroPiezas[0] == girosNecesarios[0] && giroPiezas[1] == girosNecesarios[1] && giroPiezas[2] == girosNecesarios[2])
        {
            print("resuelto");
        }
    }
}
