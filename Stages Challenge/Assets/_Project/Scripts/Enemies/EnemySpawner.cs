using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private List<Transform> _spawnPoints;

    [Header("Pool Settings")]
    [Range(1, 20)]
    [SerializeField] private int _poolSize;
    [Range(0.1f, 5f)]
    [SerializeField] private float _spawnDelay;

    private int _initialPosY = 2;

    void Start()
    {
        PoolManager.Instance.Load(_enemyPrefab, _poolSize);
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        // First enemy to spawn
        SpawnSingleEnemy();
        
        while (true)
        {
            yield return new WaitForSeconds(_spawnDelay);
            SpawnSingleEnemy();
        }
    }

    void SpawnSingleEnemy()
    {
        int index = Random.Range(0, _spawnPoints.Count);
        var randomPosition = Random.insideUnitCircle;
        Vector3 spawnPoint = new Vector3(_spawnPoints[index].position.x + randomPosition.x, _initialPosY, _spawnPoints[index].position.x + randomPosition.y);

        var enemy = PoolManager.Instance.Spawn(_enemyPrefab);
        enemy.transform.position = spawnPoint;
        enemy.transform.SetParent(_spawnPoints[index], false);
    }
}
