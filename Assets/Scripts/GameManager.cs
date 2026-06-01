using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float survivalTime;
    public int killCount;

    public GameObject gameOverPanel;
    public TMP_Text gameOverText;

    private bool isGameOver = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (isGameOver) return;

        survivalTime += Time.deltaTime;
    }

    public void AddKill()
    {
        killCount++;
        Debug.Log("Số yêu thú đã giết: " + killCount);
    }

    public void GameOver(PlayerCultivation playerCultivation)
    {
        isGameOver = true;
        Time.timeScale = 0f;

        string result =
            "THÂN TỬ ĐẠO TIÊU\n\n"
            + "Cảnh giới đạt được: " + playerCultivation.GetCultivationName() + "\n"
            + "Số yêu thú tiêu diệt: " + killCount + "\n"
            + "Thời gian sống: " + Mathf.FloorToInt(survivalTime) + " giây";

        Debug.Log(result);

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (gameOverText != null)
        {
            gameOverText.text = result;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}