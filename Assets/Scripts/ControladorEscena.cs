using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorEscena : MonoBehaviour
{
    public GameObject pj;
    public GameObject pjMenuAnimacion;
    public GameObject canvasMenu;
    public GameObject canvasGameplay;
    public GameObject canvasPerder;
    public GameObject botonPlay;
    public GameObject botonPause;
    public GameObject botonMenu;
    public GameObject botonReplay;
    public GameObject bestScoreText;
    public GameObject endScoreText;
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
    private bool paused = false;
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
        pjMenuAnimacion.SetActive(false);
        pj.GetComponent<SpriteRenderer>().enabled = true;
        Time.timeScale = 1;
        musica.Play();
        //StartCoroutine(esperaNegro());
        canvasGameplay.SetActive(true);
        canvasMenu.SetActive(false);
        botonPlay.SetActive(false);
    }
    //IEnumerator esperaNegro()
    //{
    //    squareFade.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 255);
    //    yield return new WaitForSeconds(0.1f);
    //    squareFade.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 255);
    //}

    public void PauseButton()
    {
        if (!paused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
            paused = true;

    }

    public void Perder()
    {
        //Score Saving/Displaying
        if(PlayerDataController.highScore < LogicaPuntuacion.score)
        {
            PlayerDataController.highScore = LogicaPuntuacion.score;
            PlayerPrefs.SetInt("highScore", PlayerDataController.highScore);
        }
        endScoreText.GetComponent<TextMeshProUGUI>().text = LogicaPuntuacion.score.ToString();
        bestScoreText.GetComponent<TextMeshProUGUI>().text = PlayerDataController.highScore.ToString();
        //Canvas swap
        canvasGameplay.SetActive(false);
        canvasPerder.SetActive(true);
        //Music Stop
        musica.Stop();
        //Animation Stop
        bckLyrAnim.updateMode = UnityEngine.AnimatorUpdateMode.Normal;
        mdlLyrAnim.updateMode = UnityEngine.AnimatorUpdateMode.Normal;
        terrainAnim.updateMode = UnityEngine.AnimatorUpdateMode.Normal;
        birdAnim.updateMode = UnityEngine.AnimatorUpdateMode.Normal;
        Time.timeScale = 0;
    }
    
    public void Reiniciar()
    {
        SceneManager.LoadScene(0);
    }
}
