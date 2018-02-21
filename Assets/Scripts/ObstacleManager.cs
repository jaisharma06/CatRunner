using Boo.Lang;
using System.Collections;
using System.Linq;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {
    [SerializeField]
    private Obstacle obstaclePrefab;
    [SerializeField]
    private float obstacleDuration = 1f;
    [SerializeField]
    private int totalObstacles = 10;

    [SerializeField]
    private float generatePosition = 9.5f;

    private List<Obstacle> obstaclePool;

    private void Start()
    {
        GeneratePool();
        StartCoroutine(GenerateObstacles());
    }

    private void GeneratePool()
    {
        if (obstaclePool == null)
        {
            obstaclePool = new List<Obstacle>();
        }

        for (int i = 0; i < totalObstacles; i++)
        {
            var obstacle = Instantiate(obstaclePrefab);
            obstacle.SetActive(false);
            obstaclePool.Add(obstacle);
        }
    }

    private IEnumerator GenerateObstacles()
    {
        while (true)
        {
            yield return new WaitForSeconds(obstacleDuration);
            GenerateObstacle();
        }
    }

    private void GenerateObstacle()
    {
        var obstacle = obstaclePool.First(o => o.active == false);
        if (obstacle)
        {
            obstacle.SetActive(true);
        }
    }
}
