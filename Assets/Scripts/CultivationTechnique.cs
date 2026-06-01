

[System.Serializable]
public class CultivationTechnique 
{
    public string techniqueName;
    public string description;

    public int level;
    public int maxLevel;

    public string unlockRealm;
    public string rarity;

    public CultivationTechnique
        ( string techniqueName,
          string description,
          int level,
          int maxLevel,
          string unlockRealm,
          string rarity

        )
    {
        this.techniqueName = techniqueName;
        this.description = description;
        this.level = level;
        this.maxLevel = maxLevel;
        this.unlockRealm = unlockRealm;
        this.rarity = rarity;

    }
    public bool IsMaxLevel()
    {
        return level >= maxLevel;
    }
    public void LevelUp()
    {
        if (!IsMaxLevel())
        {
            level++;
        }
    }
    public string GetDisplayName()
    {
        return techniqueName + " Tầng" + level;
    }
}
