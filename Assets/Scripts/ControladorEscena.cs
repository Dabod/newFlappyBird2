using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorEscena : MonoBehaviour
{
    public GameObject canvasMenu;
    public GameObject canvasScore;
    public GameObject canvasPerder;
    public GameObject botonPlay;
    public AudioSource musica;
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
    }

    public void Play()
    {
        if (btnPulsado)
        {
            Reiniciar();
        }
        Time.timeScale = 1;
        musica.Play();
        canvasScore.SetActive(true);
        canvasMenu.SetActive(false);
        botonPlay.SetActive(false);
        btnPulsado = true;
    }

    public void Perder()
    {
        canvasPerder.SetActive(true);
        musica.Stop();
        botonPlay.GetComponent<UnityEngine.UI.Image>().sprite = menuSprite;
        //btnSize.rect.width;
        //botonPlay.GetComponent<RectTransform>().sizeDelta()
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
