using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class BaloonManager : MonoBehaviour
{
    public static BaloonManager Instance { get; private set; }
    public Text scoreText; // UI Text to display the score
    public Text highScoreText;
    private int score = 0;
    private int HighScore = 0;
    public AudioSource audioSource; // Reference to the AudioSource on the player
    public AudioClip coinSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Prevent destruction on scene load
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }
    void Start()
    {
        LoadHighScore();
        UpdateScoreText();
        UpdateHighScoreText();
    }

    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            audioSource.PlayOneShot(coinSound);
            Destroy(collision.gameObject);
            IncreaseScore();
        }
    }
    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
        IncreaseHighScore();
    }
    public void IncreaseHighScore()
    {
        if (score > HighScore)
        {
            HighScore = score;
            UpdateHighScoreText();
            SaveHighScore();
        }
    }

    private void LoadHighScore()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0); // Load high score from PlayerPrefs
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", HighScore); // Save high score to PlayerPrefs
        PlayerPrefs.Save(); // Ensure changes are saved
    }

    public void UpdateScoreText()
    {
        scoreText.text = score.ToString(); // Update the displayed score
    }
    
    public void UpdateHighScoreText()
    {
        highScoreText.text = HighScore.ToString();
    }

    public int GetScore()
    {
        return score; // Return the current score
    }

    public int GetHighScore()
    {
        return HighScore;
    }

   
}