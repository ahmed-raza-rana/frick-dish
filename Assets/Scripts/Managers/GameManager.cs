using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    [Header("UI")] public TMP_Text timerText;
    public TMP_Text scoreText;
    
    public GameObject endLevelPanel;   // assign a simple UI panel in inspector
    public Dish currentDish;
    public TMP_Text resultText;

    [Header("Gameplay")] public float levelTime = 60;
    public int scoreTarget = 100;

    float timer;
    int score;
    public bool active;

    void Awake() => I = this;

    void Start() => StartLevel();

    void Update()
    {
        if (!active) return;
        timer -= Time.deltaTime;
        timerText.text = Mathf.CeilToInt(timer).ToString();
        if (timer <= 0) EndLevel();
    }

    public void AddScore(int pts)
    {
        score += pts;
        scoreText.text = score.ToString();
    }

    public void StartLevel()
    {
        active = true;
        timer = levelTime;
        score = 0;
        scoreText.text = "0";
    }

    public void EndLevel()
    {
        active = false;

        string outcome = score >= scoreTarget ? "SUCCESS!" : "FAILED!";
        Debug.Log($"Level Ended — Score:{score}/{scoreTarget} ({outcome})");

        if (endLevelPanel)
        {
            endLevelPanel.SetActive(true);
            if (resultText)
                resultText.text = $"Score: {score}\nTarget: {scoreTarget}\n{outcome}";
        }
    }
}