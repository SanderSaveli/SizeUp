using UnityEngine;

public class BallSpawner : MonoBehaviour 
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _playerPrefab;

    [SerializeField] private float _spawnAraeRadius = 3f;
    [SerializeField] private Vector3 _spawnAreaCenter = Vector3.zero;

    public GameObject SpawnPlayer() 
    {
        return SpawnBall(_playerPrefab, _spawnAreaCenter);
    }
    public GameObject SpawnEnemy() 
    {
        return SpawnBall(_enemyPrefab, _spawnAreaCenter);
    }

    private GameObject SpawnBall(GameObject ball, Vector3 center)
    {
        float ballRadius =
            ball.gameObject.GetComponent<CircleCollider2D>().radius;
        Vector2 SpawnPosition = FindEmptyPlaceForBall(ballRadius);
        return GameObject.Instantiate(ball, SpawnPosition, Quaternion.identity);
    }

    private Vector2 FindEmptyPlaceForBall(float ballRadius) 
    {
        int InfiniteLoopLimiter = 0;
        Vector2 SpawnPosition;
        do
        {
            InfiniteLoopLimiter++;
            SpawnPosition = _spawnAreaCenter + Random.insideUnitSphere * _spawnAraeRadius;

            if (InfiniteLoopLimiter > 100)
                throw new System.Exception("There is no empty plase for ball");
                break;
        } while (Physics2D.CircleCast(SpawnPosition, ballRadius, Vector2.zero));
        return SpawnPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(_spawnAreaCenter, _spawnAraeRadius);
    }
}
