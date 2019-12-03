using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPieza : MonoBehaviour
{
    [SerializeField]
    float velocidadAnimacion = 5;
    [SerializeField]
    int numGiros = 0;
    [SerializeField]
    int indice;
    [SerializeField]
    GameObject pieza;
    Vector3 nuevaPosicion;
    Vector3 posicionA;
    Vector3 posicionB;
    Quaternion rotacionObjetivo;
    bool activado = false;

    void Start()
    {
        nuevaPosicion = pieza.transform.position;
        posicionA = pieza.transform.position;
        posicionB = pieza.transform.position + new Vector3(0, 1, 0);
        nuevaPosicion = posicionB;
        rotacionObjetivo = Quaternion.Euler(pieza.transform.eulerAngles + new Vector3(0, 0, 60));

    }

    IEnumerator MuevePieza()
    {
        for(float i = 0; i<1/velocidadAnimacion; i+= Time.deltaTime)
        {
            pieza.transform.position = Vector3.Lerp(pieza.transform.position, nuevaPosicion, i * velocidadAnimacion);
            yield return null;
        }
        pieza.transform.position = nuevaPosicion;
        nuevaPosicion = posicionA;

        for (float i = 0; i < 1/velocidadAnimacion; i += Time.deltaTime)
        {
            pieza.transform.rotation = Quaternion.Lerp(pieza.transform.rotation, rotacionObjetivo, i * velocidadAnimacion);
            yield return null;
        }
        pieza.transform.rotation = rotacionObjetivo;
        rotacionObjetivo = Quaternion.Euler(pieza.transform.eulerAngles + new Vector3(0, 0, 60));
        numGiros++;
        
        //PARA QUE EL SCRIPT FUNCIONE LAS GEMAS TIENEN QUE SER HIJAS DIRECTAS DEL CONTROLADOR DE GIROS.
        transform.parent.GetComponent<ControlaGiros>().giroPiezas[indice] = numGiros;
        if (numGiros > 5)
        {
            numGiros = 0;
        }
        for (float i = 0; i < 1 / velocidadAnimacion; i += Time.deltaTime)
        {
            pieza.transform.position = Vector3.Lerp(pieza.transform.position, nuevaPosicion, i * velocidadAnimacion);
            yield return null;
        }
        pieza.transform.position = nuevaPosicion;
        nuevaPosicion = posicionB;
        activado = false;

    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player")&&!activado)
        {
            GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            activado = true;
            StartCoroutine(MuevePieza());
            Invoke("Apaga", 1f);
        }
    }
    void Apaga()
    {
        GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }
    //TEST----BORRAR MÁS TARDE
    private void OnMouseDown()
    {
        StartCoroutine(MuevePieza());
    }
}
