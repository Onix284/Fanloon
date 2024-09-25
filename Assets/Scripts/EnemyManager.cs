using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemy;
    private GameObject InstantiatedEnemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCars());
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void Cars()
    {
        int range = Random.Range(0, enemy.Length);
        float RandXpos = Random.Range(-1.8f, 1.8f);
        InstantiatedEnemy =  Instantiate(enemy[range], new Vector3(RandXpos, transform.position.y, transform.position.z), Quaternion.identity);
    }

    IEnumerator SpawnCars()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.5f);
            Cars();
        }
    }
}
