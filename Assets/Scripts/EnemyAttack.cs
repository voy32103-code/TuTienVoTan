using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10;
    public float attackInterval = 1f;
    public float attackRange = 1.5f;

    private float timer;
    private PlayerHealth playerHealth;

     void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
     void Update()
    {
        if (playerHealth == null) return;
            float distance = Vector3.Distance(transform.position, playerHealth.transform.position);
        if (distance <= attackRange)
        {
            timer += Time.deltaTime;
            if (timer >= attackInterval)
            {
                playerHealth.TakeDamage(damage);
                timer = 0f;
            }
        }

    }
}
