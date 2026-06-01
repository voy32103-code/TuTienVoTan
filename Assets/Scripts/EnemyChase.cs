using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform target; // The target the enemy will chase
    public float speed = 5f; // The speed at which the enemy will chase the target
    public float stopDistance = 1.2f;
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance > stopDistance)
        {
            Vector3 direction = (target.position - transform.position).normalized; // Calculate the direction towards the target
            transform.position += direction * speed * Time.deltaTime; // Move the enemy towards the target
        }

    }
}
