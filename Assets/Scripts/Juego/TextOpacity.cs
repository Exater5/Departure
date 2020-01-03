using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextOpacity : MonoBehaviour
{
    public Color color1, color2;
    public float duracion;
    TextMeshProUGUI tmPro;

    // Start is called before the first frame update
    void Start()
    {
        tmPro = GetComponent<TextMeshProUGUI>();
        tmPro.color = color1;
        StartCoroutine(CorrutinaTransicionEntreDosColores());
    }

    IEnumerator CorrutinaTransicionEntreDosColores()
    {
        for (float i = 0; i < duracion; i += Time.deltaTime)
        {
            yield return 0;
            tmPro.color = Color.Lerp(color1, color2, i / duracion);
        }

        for (float i = 0; i < duracion; i += Time.deltaTime)
        {
            yield return 0;
            tmPro.color = Color.Lerp(color2, color1, i / duracion);
        }
        StartCoroutine(CorrutinaTransicionEntreDosColores());
    }
    
}
