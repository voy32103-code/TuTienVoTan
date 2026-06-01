using UnityEngine;

public class ThunderStrike : MonoBehaviour
{
    public float attackRange = 8f;
    public float baseCooldown = 3f;
    public int baseDamage = 2;
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

        float cooldown = Mathf.Max(0.5f, baseCooldown - (thunderLevel - 1) * 0.2f);

        if (timer >= cooldown)
        {
            StrikeNearestEnemy(thunderLevel);
            timer = 0f;
        }
    }

    void StrikeNearestEnemy(int thunderLevel)
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
            int finalDamage = baseDamage + (thunderLevel - 1);

            nearestEnemy.TakeDamage(finalDamage);
            GameObject effect = Instantiate(
    thunderEffectPrefab,
    Vector3.zero,
    Quaternion.identity
);

            ThunderEffect thunderEffect = effect.GetComponent<ThunderEffect>();
            thunderEffect.Setup(nearestEnemy.transform.position);
            Debug.Log("Dẫn Lôi Thuật Tầng" + thunderLevel + " đánh " + finalDamage + " damage");
        }
    }
}