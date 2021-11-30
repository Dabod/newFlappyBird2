using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaGeneradorObstaculos : MonoBehaviour
{
    public float intervalo = 1;
    private float tiempoInicial = 0;
    public GameObject obstaculo;
    public GameObject obstaculoFacil;
    public float altura;

    // Start is called before the first frame update
    void Start()
    {
        //    obstaculoNuevo = Instantiate(obstaculo);
        //    obstaculoNuevo.transform.position = transform.position + new Vector3(0, 0, 0);
        //    Destroy(obstaculoNuevo, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoInicial > intervalo)
        {
            GameObject obstaculoNuevo;
            if (PlayerDataController.difficulty == 1)
            {
                obstaculoNuevo = Instantiate(obstaculoFacil);
                obstaculoNuevo.transform.position = transform.position + new Vector3(0, Random.Range(-altura, altura), 0);
                Destroy(obstaculoNuevo, 5);
            }
            else
            {
                obstaculoNuevo = Instantiate(obstaculo);
                obstaculoNuevo.transform.position = transform.position + new Vector3(0, Random.Range(-altura, altura), 0);
                Destroy(obstaculoNuevo, 5);
            }
            tiempoInicial = 0;
        }
        else
        {
            tiempoInicial += Time.deltaTime;
        }
    }
}
