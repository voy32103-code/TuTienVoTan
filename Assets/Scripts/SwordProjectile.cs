using UnityEngine;

public class SwordProjectile : MonoBehaviour
{
    public float speed = 12f;
    public int damage = 1;
    public float lifeTime = 3f;

    private EnemyHealth target;

    public void SetTarget(EnemyHealth enemyTarget, int projectileDamage)
    {
        target = enemyTarget;
        damage = projectileDamage;
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = (target.transform.position - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;

        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance <= 0.5f)
        {
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}