using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _spawnPoint;

    private GameObject _dummy;

    void Start()
    {
        Spawn();
    }

    void Update()
    {
        if(!_dummy)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        _dummy = Instantiate(_enemy, _spawnPoint.position, _spawnPoint.rotation);
    }
}
