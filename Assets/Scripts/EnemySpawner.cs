using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;

    private Vector3 spawnPosition;

    private float spawnTime = 2f;
    private float complicationTime;
    private int enemyCount = 1;
    public GameObject TutorialObject;
    public GameObject GameOverObject;
    private void Update()
    {
        enemyCount = Random.Range(1, enemyCount);
        spawnTime -= 1f * Time.deltaTime;
        if (spawnTime <= 0)
        {
            if (TutorialObject.activeSelf == false && GameOverObject.activeSelf == false)
            {
                _Spawner();
                spawnTime = 2f;
            }
        }

        complicationTime = complicationTime + Time.deltaTime;
        if (complicationTime >= 60)
        {
            enemyCount++;
            complicationTime = 0;
        }
    }

    public void _Spawner()
    {
        for (int i = 0; i < enemyCount; i++)
        {

            spawnPosition = new Vector3(Random.Range(-1.7f, 1.7f), Random.Range(6.5f, 7.5f), transform.position.z);
            Instantiate(enemy[Random.Range(0, enemy.Length)], spawnPosition, Quaternion.identity);
        }
    }
}
