using UnityEngine;
using TMPro;
public class CultivationUI : MonoBehaviour
{
    public PlayerCultivation playerCultivation;
    public TMP_Text cultivationText;
    void Update()
    {
        cultivationText.text =
           playerCultivation.GetCultivationName()
           + "\nTu vi: "
           + playerCultivation.currentExp
           + " / "
           + playerCultivation.requiredExp;
    }
}
