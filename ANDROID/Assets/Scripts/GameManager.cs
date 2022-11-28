using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI score_txt; 

    public TextMeshProUGUI mainScore;
    public TextMeshProUGUI highScoreText;

    public GameObject gameOver;
    public GameObject player;

    public int score = 0;
    public int highScore = 0;
    //public static GameManager Instance { set; get; }
    public static GameManager instance;
    [SerializeField]private GameObject canvasAddition;
    [SerializeField]private GameObject canvasSubtraction;
    [SerializeField]private GameObject canvasMultiplication;
    [SerializeField]private GameObject canvasDivision;
    public GameObject scoreCanvas;
    public GameObject pauseCanvas;
    public GameObject pauseCanvasFind;

    public GameObject closeButton;
    public string Addition, Subtraction, Multiplication, Division;

    bool var;
    void Start()
    {
        Scene sceneStart = SceneManager.GetActiveScene();
        highScore = PlayerPrefs.GetInt("highscore", 0);
        mainScore.text = score.ToString() + " POINTS";
        highScoreText.text = "HIGHSCORE: " + highScore.ToString();

        // if (sceneStart.name == Addition)
        // {
        //     canvasAddition = GameObject.FindGameObjectWithTag("canvasAdd");
        // }
        canvasAddition = GameObject.FindGameObjectWithTag("canvasAdd");
        canvasSubtraction = GameObject.FindGameObjectWithTag("canvasSub");
        canvasDivision = GameObject.FindGameObjectWithTag("canvasDivide");
        canvasMultiplication = GameObject.FindGameObjectWithTag("canvasMultiply");

    }

    void Awake()
    {
         if(instance == null)
         {
             instance = this;
             DontDestroyOnLoad(gameObject);
         }
         else if (instance != this)
         {
             Destroy(gameObject);
         }        
    }
    public void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        highScore = PlayerPrefs.GetInt("highscore", 0);
        player = GameObject.FindGameObjectWithTag("Player");

        pauseCanvasFind = GameObject.FindGameObjectWithTag("PauseCanvas");

        // if (scene.name == Addition)
        // {
        //     canvasAddition = GameObject.FindGameObjectWithTag("canvasAdd");
        // }
        canvasAddition = GameObject.FindGameObjectWithTag("canvasAdd");
        canvasSubtraction = GameObject.FindGameObjectWithTag("canvasSub");
        canvasDivision = GameObject.FindGameObjectWithTag("canvasDivide");
        canvasMultiplication = GameObject.FindGameObjectWithTag("canvasMultiply");

        //Instance = this;
        //DontDestroyOnLoad (gameObject);
        score_txt.SetText(score.ToString());
        mainScore.text = score_txt.text;
        //highScoreText.text = highScore.ToString();
        highScoreText.text = "HIGHSCORE: " + highScore.ToString();

        if(highScore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
    public void canAdd()
    {
        if(canvasAddition.activeInHierarchy == true)
        {
           canvasAddition.SetActive(false);
            pauseCanvas.SetActive(true);
            mainScore.text = score_txt.text;
            scoreCanvas.SetActive(false);
        }
    }

    public void canSubtract()
    {
           canvasSubtraction.SetActive(false);
            pauseCanvas.SetActive(true);
            mainScore.text = score_txt.text;
            scoreCanvas.SetActive(false);
    }

    public void canMultiply()
    {
           canvasMultiplication.SetActive(false);
            pauseCanvas.SetActive(true);
            mainScore.text = score_txt.text;
            scoreCanvas.SetActive(false);
    }

    public void canDivide()
    {
            canvasDivision.SetActive(false);
            pauseCanvas.SetActive(true);
            mainScore.text = score_txt.text;
            scoreCanvas.SetActive(false);
    }

    public void AddScore()
    {
        score += 5;
        mainScore.text = score.ToString() + " POINTS";
        SceneManager.LoadScene(Random.Range(1,4));
        player.SetActive(true);
    }

    public void Restart()
    {
        score = 0;
        pauseCanvas.SetActive(false);
        SceneManager.LoadScene(1);
        scoreCanvas.SetActive(true);

    }

    public void CloseToMenu()
    {
        closeButton.SetActive(false);
        scoreCanvas.SetActive(false);
        SceneManager.LoadScene(0);

    }    
}