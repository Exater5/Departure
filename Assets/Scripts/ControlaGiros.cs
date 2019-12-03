using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaGiros : MonoBehaviour
{
    public int[] giroPiezas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(giroPiezas[0] == 2 && giroPiezas[1] == 3 && giroPiezas[2] == 4)
        {
            print("resuelto");
        }
    }
}
