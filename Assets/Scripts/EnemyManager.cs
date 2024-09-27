using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemy;
    private GameObject InstantiatedEnemy;
    public AudioSource audioSource;
    public AudioClip exitSound, restartSound;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemis());
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void Enemies()
    {
        int range = Random.Range(0, enemy.Length);
        float RandXpos = Random.Range(-1.8f, 1.8f);
        InstantiatedEnemy =  Instantiate(enemy[range], new Vector3(RandXpos, transform.position.y, transform.position.z), Quaternion.identity);
    }

    IEnumerator SpawnEnemis()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Enemies();
        }
    }


    public void OnExitButtonClicked()
    {
        audioSource.PlayOneShot(exitSound);
        Debug.Log("game is quit");
        Application.Quit();
    }

    public void OnRestartButtonClicked()
    {
        audioSource.PlayOneShot(restartSound);
        Debug.Log("level is restarted");
        StartCoroutine(restartLevel());
        Time.timeScale = 1.0f;
    }

    IEnumerator restartLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
