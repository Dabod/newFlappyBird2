using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaAreaPuntuacion : MonoBehaviour
{
    public AudioSource puntSonido;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LogicaPuntuacion.score++;
        puntSonido.Play();
    }
}
