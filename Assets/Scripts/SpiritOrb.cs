using UnityEngine;

public class SpiritOrb : MonoBehaviour
{
    public int expValue = 5;
    public float moveSpeed = 5f;
    public float collectDistance = 1f;
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
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        float distance = Vector3.Distance(transform.position, player.position);
        if ( distance <= collectDistance)
        {
            int finalExp = techniqueManager.CalculateSpiritExp(expValue);

            Debug.Log("Base Exp: " + expValue + " | Final Exp: " + finalExp);

            playerCultivation.AddExp(finalExp);
            Destroy(gameObject);
        }

    }
}
