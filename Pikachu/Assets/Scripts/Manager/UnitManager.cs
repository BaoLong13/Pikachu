using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager instance;

    private List<ScriptableUnit> units;

    private void Awake()
    {
        instance = this;
        units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }

    public void SpawnBall()
    {
        int ballCount = 30;
        for (int i = 0; i < ballCount; ++i)
        {
            var randomPrefab = GetRandomUnit<BaseBall>(Type.Ball);
            var spawnedBall = Instantiate(randomPrefab);
            var randomSpawnedTile = GridManager.instance.GetSpawnedTile();

            randomSpawnedTile.SetUnit(spawnedBall);
        }
        GameManager.instance.ChangeState(GameState.SpawnQueueBall);
    }
    
    public void SpawnQueueBall()
    {
        int ballCount = 3;
        for (int i = 0; i < ballCount; ++i)
        {
            var randomPrefab = GetRandomUnit<BaseBall>(Type.QueueBall);
            var spawnedBall = Instantiate(randomPrefab);
            var randomSpawnedTile = GridManager.instance.GetSpawnedTile();

            spawnedBall.transform.position = randomSpawnedTile.transform.position;

        }
        GameManager.instance.ChangeState(GameState.StartTurn);
    }

    private T GetRandomUnit<T>(Type type) where T : BaseBall
    {
        return (T) units.Where(u => u.unitType == type).OrderBy(o => Random.value).First().unitPrefab;
    }
}
