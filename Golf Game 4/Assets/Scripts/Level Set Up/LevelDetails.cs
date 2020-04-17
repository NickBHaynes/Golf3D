using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDetails : MonoBehaviour
{
    public int levelNum;
    private bool levelActive = false;
    
    [Header ("Player Details")]
    public Transform[] playerSpawnPoints;
    public LayerMask playerLayer;

    [Header("Ball")]
    public GameObject ball;
    public Transform[] ballSpawnSpots;

    [Header("Enemy")]
    public GameObject[] enemy;

    public List<Transform> enemySpawnSpots;
    public Transform enemyParentObject;
    public int enemiesToSpawn = 4;
    public float newEnemySpawnTime = 10;

    [Header("Hole")]
    public GameObject hole;

    [Header("Entry Exit")]
    public GameObject entryBridge;
    public GameObject exitBridge;

    private void Start()
    {
        EventsManager.instance.OnSpawnLevelDetails += SpawnDetails;
    }

    private void SpawnDetails(int _levelnum)
    {
        if (levelNum != _levelnum)
        {
            DespawnLevel();
        } else
        {
            if (!levelActive)
            {
                EventsManager.instance.OnDestroyEnemy += SpawnEnemyAfterHit;
                EventsManager.instance.OnResetBall += ResetBall;
                EventsManager.instance.OnResetPlayer += ResetPlayer;


                Instantiate(ball, ballSpawnSpots[Random.Range(0, ballSpawnSpots.Length - 1)].position, Quaternion.identity);
                for (int i = 0; i < enemiesToSpawn; i++)
                {
                    SpawnNewEnemy();
                }
            }
            levelActive = true;
        }
    }

    private void DespawnLevel()
    {

        if (levelActive)
        {
            EventsManager.instance.OnDestroyEnemy -= SpawnEnemyAfterHit;
            EventsManager.instance.OnResetBall -= ResetBall;
            EventsManager.instance.OnResetPlayer -= ResetPlayer;

            Enemy[] enemies = FindObjectsOfType<Enemy>();
            if (FindObjectOfType<OfflineBall>() != null)
            {
                FindObjectOfType<OfflineBall>().EndGame();

            }
            foreach (Enemy e in enemies)
            {
                e.GetComponent<Enemy>().EndGame();
            }

            levelActive = false;
        }
    }

    public void EndGame()
    {
        EventsManager.instance.OnSpawnLevelDetails -= SpawnDetails;
        DespawnLevel();
    }

    private void SpawnEnemyAfterHit()
    {
        StartCoroutine(SpawnNewEnemyCo());
    }

    private IEnumerator SpawnNewEnemyCo()
    {
        yield return new WaitForSeconds(newEnemySpawnTime);
        SpawnNewEnemy();
    }

    private void SpawnNewEnemy()
    {
        int ran = Random.Range(0, enemy.Length);
        GameObject e = Instantiate(enemy[ran], enemySpawnSpots[Random.Range(0, enemySpawnSpots.Count - 1)].position, Quaternion.identity, enemyParentObject);
        e.GetComponent<EnemyController>().moveSpots = enemySpawnSpots;
    }

    public void ResetBall()
    {
        EventsManager.instance.ResetBallPos(ballSpawnSpots[Random.Range(0, ballSpawnSpots.Length - 1)]);
    }

    public void ResetPlayer()
    {
        EventsManager.instance.ResetPlayerPos(playerSpawnPoints[Random.Range(0, playerSpawnPoints.Length - 1)]);

    }

}
