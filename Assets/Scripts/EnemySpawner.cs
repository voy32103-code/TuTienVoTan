using UnityEngine;
using UnityEngine.Accessibility;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public Transform player; // Reference to the player's transform

    public float spawnRadius = 10f; // The radius within which enemies will spawn around the player
    public float spawnInterval = 2f; // Time interval between spawns

    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f; // Reset the timer after spawning an enemy
        }
    }
    void SpawnEnemy()
    {
        Vector2 randomCircle = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition = player.position +new Vector3(
            randomCircle.x,
            0f,
            randomCircle.y
            ) * spawnRadius;
        GameObject enemy = Instantiate(enemyPrefab , spawnPosition, Quaternion.identity);
        EnemyChase enemyChase = enemy.GetComponent<EnemyChase>();
        enemyChase.target = player; // Set the player's transform as the target for the enemy to chase

    }
}
