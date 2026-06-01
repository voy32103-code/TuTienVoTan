using System.Collections.Generic;
using UnityEngine;

public class ThunderStrike : MonoBehaviour
{
    public float attackRange = 8f;
    public float baseCooldown = 3f;

    public GameObject thunderEffectPrefab;
    public TechniqueManager techniqueManager;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        int thunderLevel = techniqueManager.GetTechniqueLevel("Dẫn Lôi Thuật");

        if (thunderLevel <= 0)
        {
            return;
        }

        float cooldown = GetCooldown(thunderLevel);

        if (timer >= cooldown)
        {
            CastThunder(thunderLevel);
            timer = 0f;
        }
    }

    void CastThunder(int thunderLevel)
    {
        List<EnemyHealth> targets = FindNearestEnemies(GetThunderCount(thunderLevel));

        foreach (EnemyHealth enemy in targets)
        {
            if (enemy == null) continue;

            int damage = GetThunderDamage(thunderLevel);

            enemy.TakeDamage(damage);

            SpawnThunderEffect(enemy.transform.position, thunderLevel);

            Debug.Log("Dẫn Lôi Thuật Lv" + thunderLevel + " đánh " + damage + " damage");
        }
    }

    List<EnemyHealth> FindNearestEnemies(int count)
    {
        EnemyHealth[] enemies = FindObjectsByType<EnemyHealth>(FindObjectsSortMode.None);

        List<EnemyHealth> validEnemies = new List<EnemyHealth>();

        foreach (EnemyHealth enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance <= attackRange)
            {
                validEnemies.Add(enemy);
            }
        }

        validEnemies.Sort((a, b) =>
        {
            float distanceA = Vector3.Distance(transform.position, a.transform.position);
            float distanceB = Vector3.Distance(transform.position, b.transform.position);

            return distanceA.CompareTo(distanceB);
        });

        if (validEnemies.Count > count)
        {
            validEnemies.RemoveRange(count, validEnemies.Count - count);
        }

        return validEnemies;
    }

    int GetThunderDamage(int level)
    {
        if (level >= 6) return 30; // Lôi Phạt
        if (level >= 2) return 10;
        return 5;
    }

    int GetThunderCount(int level)
    {
        if (level >= 6) return 1; // Lv6 là 1 tia sét lớn
        if (level >= 5) return 5;
        if (level >= 3) return 2;
        return 1;
    }

    float GetCooldown(int level)
    {
        if (level >= 4) return baseCooldown / 2f;
        return baseCooldown;
    }

    void SpawnThunderEffect(Vector3 targetPosition, int thunderLevel)
    {
        GameObject effect = Instantiate(
            thunderEffectPrefab,
            Vector3.zero,
            Quaternion.identity
        );

        ThunderEffect thunderEffect = effect.GetComponent<ThunderEffect>();

        thunderEffect.Setup(targetPosition);

        if (thunderLevel >= 6)
        {
            effect.transform.localScale = Vector3.one * 2f;
        }
    }
}