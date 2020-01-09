using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class MovimientoLibre : MonoBehaviour
{
    public float velocidad;
    float vertical;
    float horizontal;
    bool rodando = false;

    private void Update()
    {
        vertical = Input.GetAxis("L_YAxis_1");
        horizontal = Input.GetAxis("L_XAxis_1");
        transform.Translate(new Vector3(-horizontal, 0, vertical) * velocidad/100);

        for (int i = 0; i < 5; i++)
            ObtieneInput((GamePad.Index)i);


    }
    public void ObtieneInput(GamePad.Index controller)
    {
        GamepadState boton = GamePad.GetState(controller);
        if ((boton.RightTrigger) >= 0.5 && !rodando)
        {
            print("Activo Habilidad");
            rodando = true;
            StartCoroutine(Rueda());
        }
        transform.Rotate(new Vector3(0, boton.LeftStickAxis.x * 90, 0)*Time.deltaTime);
    }
    IEnumerator Rueda()
    {
        yield return new WaitForSeconds(1);
        print("Ya he rodado");
        rodando = false;
    }
}
