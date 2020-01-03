using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BgOpacity : MonoBehaviour
{
    [SerializeField]
    Color color1, color2;
    [SerializeField]
    float duracion;
    Image panel;
    // Start is called before the first frame update
    void Start()
    {
        panel = GetComponent<Image>();
        panel.color = color1;
        StartCoroutine(CorrutinaTransicionEntreDosColores());
    }

    IEnumerator CorrutinaTransicionEntreDosColores()
    {
        for (float i = 0; i < duracion; i += Time.deltaTime)
        {
            yield return 0;
            panel.color = Color.Lerp(color1, color2, i / duracion);
        }
    }
}
