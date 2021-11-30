using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaObstaculo : MonoBehaviour
{
    public float velocidad = 1;
    float timer = 0;
    public GameObject suelo;
    int contadorAltura = 1, contadorBajada = 0;
    bool subir, bajar;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * velocidad * Time.deltaTime;
        
        if(PlayerDataController.difficulty == 3)
        {
            timer += Time.deltaTime;

            if (contadorAltura < 1) subir = true;
            else subir = false;

            if (contadorBajada < 1) bajar = true;
            else bajar = false;

            if (subir)
            {
                transform.position += Vector3.up * 0.4f * Time.deltaTime;
                if(timer > 1f)
                {
                    contadorAltura++;
                    timer = 0f;
                }
                if (contadorAltura >= 1) contadorBajada = 0;
            }
            
            if (bajar)
            {
                transform.position += Vector3.down * 0.4f * Time.deltaTime;
                if (timer > 1f)
                {
                    contadorBajada++;
                    timer = 0f;
                }
                if (contadorBajada >= 1) contadorAltura = 0;
            }
        }
    }
}
