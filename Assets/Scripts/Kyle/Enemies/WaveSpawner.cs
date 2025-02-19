using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public TextMeshProUGUI waveCountText;
    public float spawnRate = 1.0f;
    public float timeBetweenWaves = 3.0f;
    public int enemyCount;
    public GameObject enemy;
    public Transform[] spawnPoints; // Array of spawn points

    private int waveCount = 1;
    private bool waveIsDone = true;

    void Update()
    {
        waveCountText.text = waveCount.ToString();
        if (waveIsDone)
        {
            StartCoroutine(WaveSpawnerCoroutine());
        }
    }

    IEnumerator WaveSpawnerCoroutine()
    {
        waveIsDone = false;

        for (int i = 0; i < enemyCount; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)]; // Select a random spawn point
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(spawnRate);
        }

        spawnRate = Mathf.Max(0.1f, spawnRate - 0.1f); // Prevent spawnRate from becoming too low
        enemyCount += 3;
        waveCount += 1;

        yield return new WaitForSeconds(timeBetweenWaves);
        waveIsDone = true;
    }
}