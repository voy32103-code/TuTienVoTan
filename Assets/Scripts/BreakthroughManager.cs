using UnityEngine;

public class BreakthroughManager : MonoBehaviour
{
    public PlayerCultivation playerCultivation;
    public EnemySpawner enemySpawner;

    public float breakthroughDuration = 30f;

    private bool isBreakthroughActive = false;
    private float timer;

    void Start()
    {
        playerCultivation.OnBreakthroughRequired += StartBreakthroughEvent;
    }

    void Update()
    {
        if (!isBreakthroughActive)
        {
            return;
        }

        timer += Time.deltaTime;

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

        Debug.Log("===== TIẾN GIAI BẮT ĐẦU =====");
        Debug.Log("Sống sót trong " + breakthroughDuration + " giây để đột phá cảnh giới!");
    }

    void CompleteBreakthroughEvent()
    {
        isBreakthroughActive = false;

        enemySpawner.StopTribulationMode();

        playerCultivation.CompleteBreakthrough();

        Debug.Log("===== TIẾN GIAI THÀNH CÔNG =====");
    }
}