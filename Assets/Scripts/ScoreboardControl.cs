using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreboardControl : MonoBehaviour
{
    public static ScoreboardControl Instance { get; set; }
    [SerializeField] private TextMeshProUGUI textScore;
    private int _currentScore = 0;

    private void Awake()
    {
        if (Instance is null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetScore(int score)
    {
        _currentScore += score;
        textScore.text = _currentScore.ToString();
    }
}