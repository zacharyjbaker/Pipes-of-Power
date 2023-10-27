using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PathManager path;
    [SerializeField] private Hitter hitter;
    [SerializeField] private GameObject[] enemyPrefabs;

    [SerializeField] private float spawnTimer = 4f;
    private float totalTime = 0.0f;
    [SerializeField] private float spawnRate = 2f;
    //[SerializeField] private float speedChange = 0f;

    void Start()
    {
        spawnRate = Random.Range(4, 24);
        spawnTimer = Random.Range(2, 9);
    }
    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        if (spawnTimer <= 0)
        {
            Debug.Log(totalTime);
            if (totalTime > 0)
            {
                GameObject newEnemy = Instantiate(enemyPrefabs[0], transform);
                newEnemy.GetComponent<PathFollower>().AssignPath(path);
                newEnemy.GetComponent<PathFollower>().AssignHitter(hitter);
                spawnRate = Mathf.Abs(Random.Range(4, 24) - Random.Range(0, 7));

            }
            /*
            if (totalTime > 40)
            {
                GameObject newEnemy = Instantiate(enemyPrefabs[1], transform);
                newEnemy.GetComponent<PathFollower>().AssignPath(path);
            }
            */
            spawnTimer = spawnRate;
        }

        spawnTimer -= Time.deltaTime;
    }
}
