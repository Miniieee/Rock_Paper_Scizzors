using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Movement rockEnemyPrefab;
    [SerializeField] Movement paperEnemyPrefab;
    [SerializeField] Movement scizzorsEnemyPrefab;

    [SerializeField] float timeBeetweenWawes = 2f;

    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    IEnumerator EnemySpawner()
    {
        while (true)
        {
            int enemyToSpawn = Random.Range(0, 3);

            switch (enemyToSpawn)
            {
                case 0:
                    Instantiate(rockEnemyPrefab, transform.position, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(paperEnemyPrefab, transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(scizzorsEnemyPrefab, transform.position, Quaternion.identity);
                    break;
            }

            WaweTimesDueToPoints();

            yield return new WaitForSeconds(timeBeetweenWawes);
        }
    }

    private void WaweTimesDueToPoints()
    {
        int currentScore = PlayerPrefs.GetInt("currentScore");
        if (currentScore <= 150)
        {
            timeBeetweenWawes = 2f;
        }
        else if (currentScore >= 150 && currentScore < 300)
        {
            timeBeetweenWawes = 1.8f;
        }
        else if (currentScore >= 300 && currentScore < 450)
        {
            timeBeetweenWawes = 1.7f;
        }
        else if (currentScore >= 450 && currentScore < 600)
        {
            timeBeetweenWawes = 1.6f;
        }
        else if (currentScore >= 600 && currentScore < 800)
        {
            timeBeetweenWawes = 1.5f;
        }
        else if (currentScore >= 1000)
        {
            timeBeetweenWawes = 1.4f;
        }
    }
}
