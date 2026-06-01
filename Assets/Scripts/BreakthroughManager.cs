using TMPro;
using UnityEngine;

public class BreakthroughManager : MonoBehaviour
{
    public PlayerCultivation playerCultivation;
    public EnemySpawner enemySpawner;

    public GameObject breakthroughPanel;
    public TMP_Text breakthroughText;

    public float breakthroughDuration = 30f;

    private bool isBreakthroughActive = false;
    private float timer;

    void Start()
    {
        playerCultivation.OnBreakthroughRequired += StartBreakthroughEvent;

        if (breakthroughPanel != null)
        {
            breakthroughPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (!isBreakthroughActive)
        {
            return;
        }

        timer += Time.deltaTime;

        float remainingTime = breakthroughDuration - timer;

        if (breakthroughText != null)
        {
            breakthroughText.text =
                "TIẾN GIAI BẮT ĐẦU\n"
                + "Quái triều đang tập kích!\n"
                + "Sống sót: "
                + Mathf.CeilToInt(remainingTime)
                + "s";
        }

        if (timer >= breakthroughDuration)
        {
            CompleteBreakthroughEvent();
        }
    }

    void StartBreakthroughEvent()
    {
        isBreakthroughActive = true;
        timer = 0f;

        enemySpawner.StartTribulationMode();

        if (breakthroughPanel != null)
        {
            breakthroughPanel.SetActive(true);
        }

        Debug.Log("===== TIẾN GIAI BẮT ĐẦU =====");
        Debug.Log("Sống sót trong " + breakthroughDuration + " giây để đột phá cảnh giới!");
    }

    void CompleteBreakthroughEvent()
    {
        isBreakthroughActive = false;

        enemySpawner.StopTribulationMode();

        if (breakthroughPanel != null)
        {
            breakthroughPanel.SetActive(false);
        }

        playerCultivation.CompleteBreakthrough();

        Debug.Log("===== TIẾN GIAI THÀNH CÔNG =====");
    }
}