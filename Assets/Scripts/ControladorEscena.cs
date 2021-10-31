using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorEscena : MonoBehaviour
{
    //Game Objects
    public GameObject pj;
    public GameObject pjMenuAnimation;
    public GameObject canvasMenu;
    public GameObject canvasGameplay;
    public GameObject canvasPauseMenu;
    public GameObject canvasGameOver;
    public GameObject botonPlay;
    public GameObject botonPause;
    public GameObject botonMenu;
    public GameObject botonPlayAgain;
    public GameObject bestScoreText;
    public GameObject endScoreText;
    //Audio
    public AudioSource music;
    //Animators
    public Animator bckLyrAnim;
    public Animator mdlLyrAnim;
    public Animator terrainAnim;
    public Animator birdAnim;
    //Sprites
    public Sprite pauseSprite;
    public Sprite resumeSprite;
    public Sprite bronzeMedal;
    public Sprite silverMedal;
    public Sprite goldMedal;
    public Sprite platinumMedal;
    //Booleans
    public static bool btnPulsado = false;
    public static bool paused = false;
    public static bool playing;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        playing = false;
    }


    public void Play()
    {
        playing = true;
        pjMenuAnimation.SetActive(false);
        pj.GetComponent<SpriteRenderer>().enabled = true;
        Time.timeScale = 1;
        music.Play();
        canvasGameplay.SetActive(true);
        canvasMenu.SetActive(false);
        botonPlay.SetActive(false);
    }

    public void ButtonPressed()
    {
        btnPulsado = true;
    }

    void activateAnims()
    {
        bckLyrAnim.updateMode = UnityEngine.AnimatorUpdateMode.UnscaledTime;
        mdlLyrAnim.updateMode = UnityEngine.AnimatorUpdateMode.UnscaledTime;
        terrainAnim.updateMode = UnityEngine.AnimatorUpdateMode.UnscaledTime;
        birdAnim.updateMode = UnityEngine.AnimatorUpdateMode.UnscaledTime;
    }

    void deactivateAnims()
    {
        bckLyrAnim.updateMode = UnityEngine.AnimatorUpdateMode.Normal;
        mdlLyrAnim.updateMode = UnityEngine.AnimatorUpdateMode.Normal;
        terrainAnim.updateMode = UnityEngine.AnimatorUpdateMode.Normal;
        birdAnim.updateMode = UnityEngine.AnimatorUpdateMode.Normal;
    }

    public void PauseButton()
    {
        if (!paused)
        {
            paused = true;
            Time.timeScale = 0;
            deactivateAnims();
            botonPause.GetComponent<UnityEngine.UI.Image>().sprite = resumeSprite;
        }
        else
        {
            Time.timeScale = 1;
            activateAnims();
            botonPause.GetComponent<UnityEngine.UI.Image>().sprite = pauseSprite;
            paused = false;
        }

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
        canvasGameOver.SetActive(true);
        //Music Stop
        music.Stop();
        //Animation Stop
        deactivateAnims();
        Time.timeScale = 0;
    }
    
    public void Reiniciar()
    {
        SceneManager.LoadScene(0);
    }
}
