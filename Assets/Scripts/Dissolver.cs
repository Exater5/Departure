using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolver : MonoBehaviour
{
    public Material mDisolver;
    public float duracion;

    // Start is called before the first frame update
    void Start()
    {
      //  mDisolver = GetComponent<Material>();
        mDisolver.SetFloat("Vector1_Alpha", 0f);
        StartCoroutine(TransicionAlpha());
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    IEnumerator TransicionAlpha()
    {
        mDisolver.SetFloat("Vector1_Alpha", 0f);
        for (float i = 0; i<duracion; i += Time.deltaTime)
        {
            yield return null;
            mDisolver.SetFloat("Vector1_Alpha", i/duracion);
        }
        mDisolver.SetFloat("Vector1_Alpha", 1f);
    }
}
