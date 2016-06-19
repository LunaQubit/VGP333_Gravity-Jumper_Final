using UnityEngine;
using System.Collections;

public class AiSpawnManager : MonoBehaviour
{
    public GameObject enemy;

    public float spawnTime = 3f;

    public Transform[] spawnPoint;

    public float EnemyLifetime;

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Update() { }

    public void Spawn()
    {
        if (GameManager.Instance.mHealthManager.healthCoutner <= 0)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoint.Length);

        Instantiate(enemy, spawnPoint[spawnPointIndex].position, spawnPoint[spawnPointIndex].rotation);
        enemy.GetComponent<EnemyAi>().selfDestroyTimer = EnemyLifetime;
    }
}
