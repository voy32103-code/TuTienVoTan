using System.Collections.Generic;
using UnityEngine;

public class OrbitSwordManager : MonoBehaviour
{
    public GameObject orbitSwordPrefab;
    public TechniqueManager techniqueManager;

    public float orbitRadius = 2f;
    public float orbitSpeed = 180f;
    public float heightOffset = 1.2f;

    private List<OrbitSword> swords = new List<OrbitSword>();
    private int currentSwordLevel = 0;

    void Update()
    {
        int swordLevel = techniqueManager.GetTechniqueLevel("Ngự Kiếm Thuật");

        if (swordLevel != currentSwordLevel)
        {
            currentSwordLevel = swordLevel;
            RefreshSwords(swordLevel);
        }
    }

    void RefreshSwords(int swordLevel)
    {
        foreach (OrbitSword sword in swords)
        {
            if (sword != null)
            {
                Destroy(sword.gameObject);
            }
        }

        swords.Clear();

        if (swordLevel <= 0)
        {
            return;
        }

        int swordCount = GetSwordCount(swordLevel);
        int swordDamage = GetSwordDamage(swordLevel);
        float attackCooldown = GetAttackCooldown(swordLevel);

        for (int i = 0; i < swordCount; i++)
        {
            GameObject swordObject = Instantiate(
                orbitSwordPrefab,
                transform.position,
                Quaternion.identity
            );

            OrbitSword sword = swordObject.GetComponent<OrbitSword>();

            sword.player = transform;
            sword.orbitRadius = orbitRadius;
            sword.orbitSpeed = orbitSpeed;
            sword.heightOffset = heightOffset;
            sword.damage = swordDamage;
            sword.attackCooldown = attackCooldown;

            sword.angle = 360f / swordCount * i;

            swords.Add(sword);
        }

        Debug.Log("Ngự Kiếm Thuật Tầng" + swordLevel + " | Số kiếm: " + swordCount + " | Damage: " + swordDamage);
    }

    int GetSwordCount(int level)
    {
        if (level >= 6) return 6;
        if (level >= 4) return 4;
        if (level >= 3) return 2;
        return 1;
    }

    int GetSwordDamage(int level)
    {
        if (level >= 6) return 5;
        if (level >= 5) return 4;
        if (level >= 2) return 2;
        return 1;
    }

    float GetAttackCooldown(int level)
    {
        if (level >= 6) return 0.8f;
        if (level >= 4) return 1.0f;
        return 1.5f;
    }
}