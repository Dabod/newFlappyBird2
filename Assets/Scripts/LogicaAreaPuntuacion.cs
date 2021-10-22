using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaAreaPuntuacion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LogicaPuntuacion.puntuacion++;
    }
}
