using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Properties...
    public static GameManager gameManager; 
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI congratulatoryText;
    public Image gameEndMenu;
    public Image mainMenu;
    public Image healthBar;
    private int score;
    private int countdown;
    public bool gameIsCompleted;

    public GameObject[] animals;
    int animalIndex;
    int positionIndex;
    private float[] spawnPosition = { -10.0f, 0.0f, 10.0f };

    private void OnEnable()
    {
        if(!gameManager)
        {
            gameManager = this;
        }    
        if(gameManager != this)
        {
            DontDestroyOnLoad(gameManager);
            Destroy(gameManager);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameIsCompleted = true;
        score = 0;
        scoreText.text = "Score : " + score;
        countdown = 30;
        countdownText.text = countdown.ToString();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }
    public void SpawnAnimal()
    {
        animalIndex = Random.Range(0, animals.Length);
        positionIndex = Random.Range(0, spawnPosition.Length);
        Instantiate<GameObject>(animals[animalIndex], new Vector3(spawnPosition[positionIndex], transform.position.y, transform.position.z), transform.rotation);
    }

    private void CountdownTimer()
    {
        if(countdown > 0)
        {
            countdown--;
            countdownText.text = countdown.ToString();
        }
        else
        {
            gameIsCompleted = true;
            CancelInvoke("SpawnAnimal");
            ResultComment();
        }
    }
    //Function handling congratulatory message after game is completed...
    public void ResultComment()
    {
        countdown = 0;
        countdownText.text = countdown.ToString();
        if (score >= 70 && score > 60)
        {
            congratulatoryText.text = "Excellent!";
        }
        else if(score<=60 && score >= 30)
        {
            congratulatoryText.text = "Good Job!";
        }
        else if(score < 30)
        {
            congratulatoryText.text = "Try Again!";
        }
        gameEndMenu.gameObject.SetActive(true);
    }

    public void ResetGame()
    {
        gameEndMenu.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        mainMenu.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        countdownText.gameObject.SetActive(true);
        healthBar.gameObject.SetActive(true);
        gameIsCompleted = false;
        InvokeRepeating("CountdownTimer", 1.0f, 1.0f);
        InvokeRepeating("SpawnAnimal", 2.0f, 2.0f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
