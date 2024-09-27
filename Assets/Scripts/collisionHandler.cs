using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollisionHandler : MonoBehaviour
{
    public static CollisionHandler Instance { get; private set; }
    public GameObject deathPanel;
    public Text deathScoreText;
    public Text highScoreText;
    public GameObject fan;
    public AudioSource deathSound;
    public ParticleSystem deathParticle;
    public SpriteRenderer deathSprite;
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

    private void Start()
    {
        if (deathPanel != null)
        {
            deathPanel.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy"))
        {
            deathSound.Play();
            deathParticle.Play();
            deathSprite.enabled = false;
            StartCoroutine(destroyWait());
        }
    }

    private void HandlePlayerDeath()
    {
        
        ShowDeathPanel();
        deathScoreText.text = BaloonManager.Instance.GetScore().ToString();
        highScoreText.text = BaloonManager.Instance.GetHighScore().ToString();
        //Destroy(gameObject); // Destroy the player object
        Destroy(gameObject);
        Destroy(fan);
    }

    private IEnumerator destroyWait()
    {
        yield return new WaitForSeconds(2f);
        HandlePlayerDeath();

    }

    private void ShowDeathPanel()
    {
        if (deathPanel != null)
        {
            deathPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

   
}
