using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager instance;

    public BaseBall selectedBall;

    private List<ScriptableUnit> units;
    public List<BaseBall> queuedBalls;

    private void Awake()
    {
        instance = this;
        units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }

    public void SpawnBall()
    {
        int ballCount = 20;
        for (int i = 0; i < ballCount; ++i)
        {
            var randomPrefab = GetRandomUnit<BaseBall>(Type.Ball);
            var spawnedBall = Instantiate(randomPrefab);
            var randomSpawnedTile = GridManager.instance.GetSpawnedTile();

            randomSpawnedTile.SetUnit(spawnedBall);
        }
        GameManager.instance.ChangeState(GameState.StartTurn);
    }
    
    public void SpawnQueueBall()
    {
        int ballCount = 3;
        for (int i = 0; i < ballCount; ++i)
        {
            var randomPrefab = GetRandomUnit<BaseBall>(Type.QueueBall);
            var spawnedBall = Instantiate(randomPrefab);
            var randomSpawnedTile = GridManager.instance.GetSpawnedTile();

            queuedBalls.Add(spawnedBall); // Save queueBall current position

            randomSpawnedTile.SetUnit(spawnedBall);

        }
    }
    
    public void SpawnGhostBall()
    {
        int ballCount = 3;
        for (int i = 0; i < ballCount; ++i)
        {
            var randomPrefab = GetRandomUnit<BaseBall>(Type.GhostBall);
            var spawnedBall = Instantiate(randomPrefab);
            var randomSpawnedTile = GridManager.instance.GetSpawnedTile();

            randomSpawnedTile.SetUnit(spawnedBall);
        }
    }

    public void DequeueBall()
    {
        foreach (BaseBall ball in queuedBalls)
        {
            if (ball != null)
            {
                BaseBall newBall = ball;
                newBall.transform.localScale = Vector3.one; // Change size to fit ColorBall
                newBall.type = Type.Ball;
                ball.occupiedTile.SetUnit(newBall);
            }
        }
        queuedBalls.Clear();
        GameManager.instance.ChangeState(GameState.StartTurn);
    }
    private T GetRandomUnit<T>(Type type) where T : BaseBall
    {
        return (T) units.Where(u => u.unitType == type).OrderBy(o => Random.value).First().unitPrefab;
    }

    public void SetSelectedBall(BaseBall ball)
    {
        selectedBall = ball;
    }
}
