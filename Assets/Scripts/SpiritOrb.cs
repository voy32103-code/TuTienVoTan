using UnityEngine;

public class SpiritOrb : MonoBehaviour
{
    public int expValue = 5;

    public float moveSpeed = 5f;
    public float collectDistance = 1f;

    public float baseAbsorbRange = 5f;
    public float boostedAbsorbRange = 10f;

    private TechniqueManager techniqueManager;
    private Transform player;
    private PlayerCultivation playerCultivation;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        player = playerObject.transform;
        playerCultivation = playerObject.GetComponent<PlayerCultivation>();
        techniqueManager = playerObject.GetComponent<TechniqueManager>();
    }

    void Update()
    {
        float absorbRange = baseAbsorbRange;

        int qiLevel = techniqueManager.GetTechniqueLevel("Dẫn Khí Quyết");

        if (qiLevel >= 3)
        {
            absorbRange = boostedAbsorbRange;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > absorbRange)
        {
            return;
        }

        Vector3 direction = (player.position - transform.position).normalized;

        transform.position += direction * moveSpeed * Time.deltaTime;

        float collectDistanceCheck = Vector3.Distance(transform.position, player.position);

        if (collectDistanceCheck <= collectDistance)
        {
            int finalExp = techniqueManager.CalculateSpiritExp(expValue);

            playerCultivation.AddExp(finalExp);

            Destroy(gameObject);
        }
    }
}