using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPersonaje : MonoBehaviour
{
    public float velocity = 1.6f;
    private Rigidbody2D rb;
    public Animator animator;
    public ControladorEscena controladorEscena;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Condició apretar botó
        if (!ControladorEscena.btnPulsado) // Si no se esta pulsando un botón
        {
            if (!ControladorEscena.paused) // Si no esta en pausa
            {
                if (Input.GetMouseButtonDown(0) && ControladorEscena.playing) // El personaje vuela hacia arriba
                {
                    rb.velocity = Vector2.up * velocity;
                    animator.SetTrigger("Tap");
                }
            }

        }
        else
        {
            ControladorEscena.btnPulsado = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        controladorEscena.Perder();
    }
}
