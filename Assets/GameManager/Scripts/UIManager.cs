using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreValue;
    [SerializeField] TextMeshProUGUI timeValue;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI endScoreValue;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreUI(0);
        UpdateTimeUI(0);
    }

    public void UpdateScoreUI(int value)
    {
        scoreValue.text = value.ToString("D1");
    }

    public void UpdateTimeUI(float time)
    {
        int seconds = (int)time;
        timeValue.text = System.TimeSpan.FromSeconds(seconds).ToString("hh':'mm':'ss");
    }

    public void ActivateEndGame(int score)
    {
        endScoreValue.text = score.ToString();
        gameOverPanel.SetActive(true);
        Cursor.visible = true;
    }
}
