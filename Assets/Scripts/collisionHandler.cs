using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisionHandler : MonoBehaviour
{
    public bool playerIsDead = false; 

    void Start()
    {
        
    }

    void Update()
    {
        if (playerIsDead)
        {
            StartCoroutine(RestartLevel());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Baloon"))
        {
            Destroy(collision.gameObject);
            playerIsDead = true;
        }
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(1.5f);
        Scene currenScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currenScene.name);
    }
}
