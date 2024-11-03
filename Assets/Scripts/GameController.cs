using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject gameOverTxt;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    private int score = 0;
    private int hiScore = 0;
    public Text scoreText;
    public Text hiScoreText;
    public AudioSource scoreSound;

    //Awake is called before Start
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        hiScore = PlayerPrefs.GetInt("HiScore", 0);
        hiScoreText.text = "HI " + hiScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void PlayerDied()
    {
        gameOverTxt.SetActive(true);
        gameOver = true;

        if(score > hiScore)
        {
            PlayerPrefs.SetInt("HiScore", score);
        }
    }

    public void Scored()
    {
        if(!gameOver)
        {
            score++;
            scoreText.text = score.ToString();
            scoreSound.Play();
        }
    }
}
