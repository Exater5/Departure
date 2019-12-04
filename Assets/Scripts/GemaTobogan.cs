using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemaTobogan : MonoBehaviour
{
    public GameObject tobogan;
    public Material eMaterial;
    public float duracion;
    // Start is called before the first frame update
    void Start()
    {
        eMaterial.SetFloat("_EmissiveIntensity", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag("Player"))
        {
            tobogan.SetActive(true);
          //  StartCoroutine(TransicionEmisiva());
        }
    }
    IEnumerator TransicionEmisiva()
    {
        for(float i = 0; i<duracion; i += Time.deltaTime)
        {
            print(eMaterial.name);
            print(eMaterial.GetFloat("_EmissiveIntensity"));
            eMaterial.SetFloat("_EmissiveIntensity", eMaterial.GetFloat("_EmissiveIntensity") + (i * 3));
            yield return null;
        }
    }
}
