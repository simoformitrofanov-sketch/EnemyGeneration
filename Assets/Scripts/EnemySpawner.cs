using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform _target;
    [SerializeField] private float _spawnInterval = 2f;

    private Coroutine _spawnRoutine;

    private void OnEnable()
    {
        _spawnRoutine = StartCoroutine(SpawnLoop());
    }

    private void OnDisable()
    {
        if (_spawnRoutine != null)
        {
            StopCoroutine(_spawnRoutine);
            _spawnRoutine = null;
        }
    }

    private IEnumerator SpawnLoop()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnInterval);

        while (enabled)
        {
            yield return wait;
            Spawn();
        }
    }

    private void Spawn()
    {
        Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        Vector3 direction = (_target.position - spawnPoint.position).normalized;

        Enemy enemy = Instantiate(_enemyPrefab, spawnPoint.position, Quaternion.identity);
        enemy.Init(direction);
    }
}