using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
public class SceneManager : MonoBehaviour
{
    bool wasted;
    public GameObject panelMuerte;
    // Start is called before the first frame update
    void Start()
    {
        wasted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(wasted == true && Input.anyKeyDown)
        {
            EditorSceneManager.LoadScene(1);
        }
    }
    public void RestartEnabled()
    {
        StartCoroutine("CanReplay");
    }
    IEnumerator CanReplay()
    {
        yield return new WaitForSeconds(2f);
        wasted = true;
        panelMuerte.SetActive(true);
    }
}
