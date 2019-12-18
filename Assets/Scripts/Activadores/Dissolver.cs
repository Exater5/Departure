using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolver : MonoBehaviour
{
    public Material mDisolver;
    public float duracion;
    MeshCollider c;
    // Start is called before the first frame update
    void Start()
    {
        //  mDisolver = GetComponent<Material>();
        c = GetComponent<MeshCollider>();
        mDisolver.SetFloat("Vector1_Alpha", 0f);
        StartCoroutine(TransicionAlpha());
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    IEnumerator TransicionAlpha()
    {
        c.enabled = false;
        mDisolver.SetFloat("Vector1_Alpha", 0f);
        for (float i = 0; i<duracion; i += Time.deltaTime)
        {
            yield return null;
            mDisolver.SetFloat("Vector1_Alpha", i/duracion);
        }
        mDisolver.SetFloat("Vector1_Alpha", 1f);
        c.enabled = true;
    }
}
