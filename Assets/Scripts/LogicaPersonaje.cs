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
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * velocity;
            //rb.transform.eulerAngles = Vector3.forward * 20;
            animator.SetTrigger("Tap");
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        controladorEscena.Perder();
    }
}
