using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private List<Enemy> enemies;
    [SerializeField] private Transform spawnPointsContainer;
    [SerializeField] private Door[] doors;
    private List<Transform> spawnPoints;
    private List<Transform> leftSpawnPoints;

    private void Awake()
    {
        foreach (Transform child in spawnPointsContainer)
        {
            spawnPoints.Add(child);
            leftSpawnPoints.Add(child);
        }
    }

    private void SetEnemyPosition(Enemy enemy)
    {
        var spawnIndex = Random.Range(0, leftSpawnPoints.Count);
        enemy.transform.position = leftSpawnPoints[spawnIndex].position;
        leftSpawnPoints.Remove(leftSpawnPoints[spawnIndex]);
    }

    public void SpawnEnemies(List<Enemy> enemies)
    {
        foreach (var enemy in enemies)
        {
            if (leftSpawnPoints.Count < 1)
            {
                Debug.LogError("spawn points end!");
                break;
            }
            SetEnemyPosition(enemy);
            enemy.OnDie += EnemyDieHandler;
            enemies.Add(enemy);
        }
        foreach (var door in doors)
        {
            door.DisableDoor();
        }
    }

    private void EnemyDieHandler(Enemy enemy)
    {
        enemies.Remove(enemy);
        enemy.OnDie -= EnemyDieHandler;
        if(enemies.Count < 1)
        {
            OpenDoors();
        }
    }

    private void OpenDoors()
    {
        foreach (var door in doors)
        {
            door.EnableDoor();
        }
    }
}
