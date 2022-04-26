using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject[] _enemyTemplates;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn = 3.0f;

    private float _elapsedTime = 0.0f;
    private float _elapsedTimeLife = 0.0f;
    private float _waitSeconds = 5.0f;

    private void Start()
    {
        Initialize(_enemyTemplates);
        StartCoroutine(SpeedSpawn());
    }

    private void Update()
    {        
        _elapsedTime += Time.deltaTime;        

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if(TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
            }       
        }

        _elapsedTimeLife += Time.deltaTime;

        if (_elapsedTimeLife >= 60)
        {
            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
            LifeInstantiate(_life, _spawnPoints[spawnPointNumber]);
            _elapsedTimeLife = 0;
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    private IEnumerator SpeedSpawn()
    {
        while (!_player.StopGame())
        {
            if (_secondsBetweenSpawn > 2)
            {
                _secondsBetweenSpawn -= 0.2f;
                yield return new WaitForSeconds(_waitSeconds);
            }
            else if (_secondsBetweenSpawn > 1)
            {
                _secondsBetweenSpawn -= 0.1f;
                yield return new WaitForSeconds(_waitSeconds);
            }
            else if (_secondsBetweenSpawn > 0.5f)
            {
                _secondsBetweenSpawn -= 0.05f;
                yield return new WaitForSeconds(_waitSeconds);
            }
            else if (_secondsBetweenSpawn > 0.25f)
            {
                _secondsBetweenSpawn -= 0.01f;
                yield return new WaitForSeconds(_waitSeconds);
            } else
            {
                _secondsBetweenSpawn = 0.25f;
                yield return new WaitForSeconds(_waitSeconds);
            }
        }        
    }
}
