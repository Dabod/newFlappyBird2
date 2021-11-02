using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorEscena : MonoBehaviour
{
    // Player
    public GameObject pj;
    public GameObject pjMenuAnimation;
    // HUD
    public GameObject canvasMenu;
    public GameObject canvasGameplay;
    public GameObject canvasPauseMenu;
    public GameObject canvasGameOver;
    // Buttons
    public GameObject botonPlay;
    public GameObject botonPause;
    public GameObject botonMenu;
    public GameObject botonPlayAgain;
    // Text
    public GameObject bestScoreText;
    public GameObject endScoreText;
    public GameObject newBestScoreText;
    public GameObject medalGotText;
    // Images
    public GameObject ScoreMedal;
    public GameObject musicIcon;
    public GameObject soundIcon;
    // Audio
    public AudioSource music;
    public AudioSource sonidoPunt;
    // Animators
    public Animator bckLyrAnim;
    public Animator mdlLyrAnim;
    public Animator terrainAnim;
    public Animator birdAnim;
    // Sprites
    public Sprite pauseSprite;
    public Sprite resumeSprite;
    public Sprite bronzeMedal;
    public Sprite silverMedal;
    public Sprite goldMedal;
    public Sprite platinumMedal;
    public Sprite musicOnIcon;
    public Sprite musicOffIcon;
    public Sprite soundOnIcon;
    public Sprite soundOffIcon;
    // Booleans
    public static bool btnPulsado = false;
    public static bool paused = false;
    public static bool playing;
    public static bool musicOn = true;
    public static bool soundOn = true;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        loadPlayerData();
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

    void loadPlayerData()
    {
        PlayerDataController.highScore = PlayerPrefs.GetInt("highScore", 0);
        musicOn = intToBool(PlayerPrefs.GetInt("musicOn", 1));

        // Aplicamos los cambios a la musica y al sprite de su botón.
        if (musicOn)
        {
            music.volume = 0.75f;
            musicIcon.GetComponent<UnityEngine.UI.Image>().sprite = musicOnIcon;
        }
        else
        {
            music.volume = 0f;
            musicIcon.GetComponent<UnityEngine.UI.Image>().sprite = musicOffIcon;
        }

        // Aplicamos los cambios al sprite del botón sonido ya que el bool es suficiente para que surja efecto.
        soundOn = intToBool(PlayerPrefs.GetInt("soundOn", 1));
        if(soundOn) soundIcon.GetComponent<UnityEngine.UI.Image>().sprite = soundOnIcon;
        else soundIcon.GetComponent<UnityEngine.UI.Image>().sprite = soundOffIcon;
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
            music.Pause();
            canvasPauseMenu.SetActive(true);
            paused = true;
            Time.timeScale = 0;
            deactivateAnims();
            botonPause.GetComponent<UnityEngine.UI.Image>().sprite = resumeSprite;
        }
        else
        {
            music.Play();
            canvasPauseMenu.SetActive(false);
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
            PlayerPrefs.Save();
            newBestScoreText.SetActive(true);
        }
        endScoreText.GetComponent<TextMeshProUGUI>().text = LogicaPuntuacion.score.ToString();
        bestScoreText.GetComponent<TextMeshProUGUI>().text = PlayerDataController.highScore.ToString();
        medalAwardDisplay();
        //Canvas swap
        canvasGameplay.SetActive(false);
        canvasGameOver.SetActive(true);
        //Music Stop
        music.Stop();
        //Animation Stop
        deactivateAnims();
        Time.timeScale = 0;
    }

    void medalAwardDisplay()
    {
        if (LogicaPuntuacion.score > 24)
        {
            ScoreMedal.SetActive(true);
            medalGotText.SetActive(true);
            if(LogicaPuntuacion.score > 99)
            {
                ScoreMedal.GetComponent<UnityEngine.UI.Image>().sprite = platinumMedal;
            }
            else if(LogicaPuntuacion.score > 74)
            {
                ScoreMedal.GetComponent<UnityEngine.UI.Image>().sprite = goldMedal;
            }
            else if (LogicaPuntuacion.score > 49)
            {
                ScoreMedal.GetComponent<UnityEngine.UI.Image>().sprite = silverMedal;
            }
        }
    }

    public void MusicOnOff()
    {
        if (musicOn)
        {
            music.volume = 0f;
            musicIcon.GetComponent<UnityEngine.UI.Image>().sprite = musicOffIcon;
            musicOn = false;
        }
        else
        {
            music.volume = 0.75f;
            musicIcon.GetComponent<UnityEngine.UI.Image>().sprite = musicOnIcon;
            musicOn = true;
        }

        PlayerPrefs.SetInt("musicOn", boolToInt(musicOn));
    }

    public void SoundOnOff()
    {
        if (soundOn)
        {
            soundIcon.GetComponent<UnityEngine.UI.Image>().sprite = soundOffIcon;
            soundOn = false;
        }
        else
        {
            soundIcon.GetComponent<UnityEngine.UI.Image>().sprite = soundOnIcon;
            soundOn = true;
        }

        PlayerPrefs.SetInt("soundOn", boolToInt(soundOn));
    }

    int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(0);
    }
}
