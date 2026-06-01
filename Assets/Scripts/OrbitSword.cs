using UnityEngine;

public class OrbitSword : MonoBehaviour
{
    public Transform player;

    public float orbitRadius = 2f;
    public float orbitSpeed = 180f;
    public float heightOffset = 1.2f;
    public float attackRange = 6f;
    public float flySpeed = 12f;
    public int damage = 1;

    public float attackCooldown = 1.5f;
    private float cooldownTimer = 0f;

    public float angle;

    private EnemyHealth target;
    private SwordState state = SwordState.Orbiting;

    private enum SwordState
    {
        Orbiting,
        Attacking,
        Returning
    }

    void Update()
    {
        if (player == null) return;

        cooldownTimer += Time.deltaTime;

        if (state == SwordState.Orbiting)
        {
            OrbitAroundPlayer();

            if (cooldownTimer >= attackCooldown)
            {
                FindTarget();
            }
        }
        else if (state == SwordState.Attacking)
        {
            AttackTarget();
        }
        else if (state == SwordState.Returning)
        {
            ReturnToOrbit();
        }
    }

    void OrbitAroundPlayer()
    {
        angle += orbitSpeed * Time.deltaTime;

        Vector3 orbitPosition = GetOrbitPosition();

        transform.position = orbitPosition;

        Vector3 directionAroundPlayer = (orbitPosition - player.position).normalized;

        if (directionAroundPlayer != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(directionAroundPlayer);
        }
    }

    Vector3 GetOrbitPosition()
    {
        float rad = angle * Mathf.Deg2Rad;

        Vector3 offset = new Vector3(
            Mathf.Cos(rad),
            0f,
            Mathf.Sin(rad)
        ) * orbitRadius;

        Vector3 height = Vector3.up * heightOffset;

        return player.position + height + offset;
    }

    void FindTarget()
    {
        EnemyHealth[] enemies = FindObjectsByType<EnemyHealth>(FindObjectsSortMode.None);

        EnemyHealth nearestEnemy = null;
        float nearestDistance = attackRange;

        foreach (EnemyHealth enemy in enemies)
        {
            float distance = Vector3.Distance(player.position, enemy.transform.position);

            if (distance <= nearestDistance)
            {
                nearestEnemy = enemy;
                nearestDistance = distance;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy;
            state = SwordState.Attacking;
        }
    }

    void AttackTarget()
    {
        if (target == null)
        {
            state = SwordState.Returning;
            return;
        }

        Vector3 targetPosition = target.transform.position + Vector3.up * 1f;

        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            flySpeed * Time.deltaTime
        );

        float distance = Vector3.Distance(transform.position, targetPosition);

        if (distance <= 0.3f)
        {
            target.TakeDamage(damage);

            cooldownTimer = 0f;

            target = null;
            state = SwordState.Returning;
        }
    }

    void ReturnToOrbit()
    {
        Vector3 orbitPosition = GetOrbitPosition();

        Vector3 moveDirection = (orbitPosition - transform.position).normalized;

        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            orbitPosition,
            flySpeed * Time.deltaTime
        );

        float distance = Vector3.Distance(transform.position, orbitPosition);

        if (distance <= 0.3f)
        {
            state = SwordState.Orbiting;
        }
    }
}