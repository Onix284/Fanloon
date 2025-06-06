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
            StartCoroutine(DeathSequence());

        }

    }

    private IEnumerator DeathSequence()
    {

        deathScoreText.text = BaloonManager.Instance.GetScore().ToString();
        highScoreText.text = BaloonManager.Instance.GetHighScore().ToString();

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0f;

        Destroy(fan);


        // Play effects
        deathSound.Play();
        deathParticle.Play();

        // Wait while effects play
        yield return new WaitForSeconds(deathParticle.main.duration);

        // Show death panel and destroy
        ShowDeathPanel();
        Destroy(gameObject);
       
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
