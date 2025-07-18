using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_script : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    public float obstacleSpawnTime = 2f;
    public float obstacleSpeed = 1f;
    private float obstacleUntilSpawnTime;

    [SerializeField] private Transform obstacleParent;

    private void Update()
    {
        if (GameManager.instance.isPlaying)
        {
            SpawnLoop();
        }
        
    }

    private void Start()
    {
        GameManager.instance.gameOver.AddListener(ClearObstacles);
    }

    private void SpawnLoop()
    {
        obstacleUntilSpawnTime += Time.deltaTime;

        if(obstacleUntilSpawnTime >= obstacleSpawnTime)
        {
            Spawn();
            obstacleUntilSpawnTime = 0f;
        }
    }

    private void ClearObstacles()
    {
        foreach(Transform child in obstacleParent)
        {
            Destroy(child.gameObject);
        }
    }

    private void Spawn()
    {
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);

        spawnedObstacle.transform.parent = obstacleParent;

        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * obstacleSpeed;
    }
}
