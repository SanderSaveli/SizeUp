using UnityEngine;

public class BallSpawner : MonoBehaviour 
{
    public GameObject EnemyPrefab;
    public GameObject PlayerPrefab;

    private float _spawnAraeRadius = 3f;

    private const int InfiniteLoopLimiter = 100;

    public GameObject SpawnPlayer(Vector3 position) 
    {
        return SpawnBall(PlayerPrefab, position);
    }
    public GameObject SpawnEnemy(Vector3 position) 
    {
        return SpawnBall(EnemyPrefab, position);
    }

    private GameObject SpawnBall(GameObject ball, Vector3 center)
    {
        int i = 0;
        Vector2 SpawnPosition;
        float SphereRadius =
            ball.gameObject.GetComponent<CircleCollider2D>().radius;
        do
        {
            i++;
            SpawnPosition = Random.insideUnitSphere * _spawnAraeRadius;

            if (i > InfiniteLoopLimiter) 
                break;
        } while (Physics2D.CircleCast(
            SpawnPosition,
            SphereRadius,
            Vector2.zero));

        return GameObject.Instantiate(ball, SpawnPosition, Quaternion.identity);
    }
}
