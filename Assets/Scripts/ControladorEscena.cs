using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorEscena : MonoBehaviour
{
    public GameObject pj;
    public GameObject pjMenuAnimacion;
    public GameObject canvasMenu;
    public GameObject canvasScore;
    public GameObject canvasPerder;
    public GameObject botonPlay;
    public GameObject squareFade;
    public AudioSource musica;
    public Animator bckLyrAnim;
    public Animator mdlLyrAnim;
    public Animator terrainAnim;
    public Animator birdAnim;
    public Sprite playSprite;
    public Sprite menuSprite;
    //public RectTransform btnSize;
    public bool btnPulsado = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        pj.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Play()
    {
        if (btnPulsado)
        {
            Reiniciar();
        }
        pjMenuAnimacion.SetActive(false);
        pj.GetComponent<SpriteRenderer>().enabled = true;
        Time.timeScale = 1;
        musica.Play();
        //StartCoroutine(esperaNegro());
        canvasScore.SetActive(true);
        canvasMenu.SetActive(false);
        botonPlay.SetActive(false);
        btnPulsado = true;
    }
    //IEnumerator esperaNegro()
    //{
    //    squareFade.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 255);
    //    yield return new WaitForSeconds(0.1f);
    //    squareFade.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 255);
    //}

    public void Perder()
    {
        canvasPerder.SetActive(true);
        musica.Stop();
        botonPlay.GetComponent<UnityEngine.UI.Image>().sprite = menuSprite;
        //btnSize.rect.width;
        //botonPlay.GetComponent<RectTransform>().sizeDelta()
        bckLyrAnim.updateMode = UnityEngine.AnimatorUpdateMode.Normal;
        mdlLyrAnim.updateMode = UnityEngine.AnimatorUpdateMode.Normal;
        terrainAnim.updateMode = UnityEngine.AnimatorUpdateMode.Normal;
        birdAnim.updateMode = UnityEngine.AnimatorUpdateMode.Normal;
        botonPlay.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void Reiniciar()
    {
        SceneManager.LoadScene(0);
    }
}
