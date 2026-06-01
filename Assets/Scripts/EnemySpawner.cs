using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject eliteEnemyPrefab;

    public Transform player;
    public PlayerCultivation playerCultivation;

    public float spawnRadius = 10f;
    public float spawnInterval = 3f;

    public float eliteSpawnChance = 0.15f;

    private float timer;

    private bool isTribulationMode = false;
    private float normalSpawnInterval;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        Vector2 randomCircle = Random.insideUnitCircle.normalized;

        Vector3 spawnPosition = player.position + new Vector3(
            randomCircle.x,
            0f,
            randomCircle.y
        ) * spawnRadius;

        GameObject prefabToSpawn = enemyPrefab;

        if (CanSpawnEliteEnemy())
        {
            float randomValue = Random.value;

            if (randomValue <= eliteSpawnChance)
            {
                prefabToSpawn = eliteEnemyPrefab;
            }
        }

        GameObject enemy = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        EnemyChase enemyChase = enemy.GetComponent<EnemyChase>();
        enemyChase.target = player;
    }

    bool CanSpawnEliteEnemy()
    {
        if (playerCultivation == null)
        {
            return false;
        }

        if (playerCultivation.realmIndex == 0 && playerCultivation.stage >= 6)
        {
            return true;
        }

        if (playerCultivation.realmIndex > 0)
        {
            return true;
        }

        return false;
    }

    public void StartTribulationMode()
    {
        isTribulationMode = true;
        normalSpawnInterval = spawnInterval;
        spawnInterval = 0.5f;

        Debug.Log("Quái triều bắt đầu! Yêu thú đang điên cuồng tập kích!");
    }

    public void StopTribulationMode()
    {
        isTribulationMode = false;
        spawnInterval = normalSpawnInterval;

        Debug.Log("Quái triều kết thúc.");
    }
}