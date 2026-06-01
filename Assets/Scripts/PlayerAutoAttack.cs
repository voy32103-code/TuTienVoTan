using UnityEngine;

public class PlayerAutoAttack : MonoBehaviour
{
    public float attackRange = 6f;
    public float attackInterval = 1f;
    public int damage = 1;

    public GameObject swordProjectilePrefab;
    public TechniqueManager techniqueManager;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= attackInterval)
        {
            AttackNearestEnemy();
            timer = 0f;
        }
    }

    void AttackNearestEnemy()
    {
        EnemyHealth[] enemies = FindObjectsByType<EnemyHealth>(FindObjectsSortMode.None);

        EnemyHealth nearestEnemy = null;
        float nearestDistance = attackRange;

        foreach (EnemyHealth enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance <= nearestDistance)
            {
                nearestEnemy = enemy;
                nearestDistance = distance;
            }
        }

        if (nearestEnemy != null)
        {
            int swordLevel = techniqueManager.GetTechniqueLevel("Ngự Kiếm Thuật");
            int finalDamage = damage + (swordLevel - 1);

            GameObject sword = Instantiate(
                swordProjectilePrefab,
                transform.position + Vector3.up,
                Quaternion.identity
            );

            SwordProjectile projectile = sword.GetComponent<SwordProjectile>();
            projectile.SetTarget(nearestEnemy, finalDamage);

            Debug.Log("Ngự Kiếm Thuật Tầng" + swordLevel + " gây " + finalDamage + " damage");
        }
    }

    public void IncreaseDamage(int amount)
    {
        damage += amount;
        Debug.Log("Sát thương cơ bản hiện tại: " + damage);
    }
}