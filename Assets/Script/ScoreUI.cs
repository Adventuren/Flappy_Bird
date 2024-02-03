using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    private EventHandler OnScoreUpdatedEvent;
    [SerializeField]
    private Text ScoreText;
    [SerializeField]
    private Text HighScoreText;
   


    private void Start()
    {
        HighScoreText.text = $"Highscore : {ManagerContainer.Instance.Score.Highscore}";
        
    }
    public void AddEvent()
    {
        ManagerContainer.Instance.Score.ScoreUpdatedEvent += OnScoreUpdated;
        ManagerContainer.Instance.Score.HighScoreUpdatedEvent += OnHighScoreUpdated;

    }

    private void OnScoreUpdated(object sender, EventArgs e)
    {
        ScoreText.text = $"Score: {ManagerContainer.Instance.Score.Score}";
    }

    private void OnHighScoreUpdated(object sender, EventArgs e)
    {
        HighScoreText.text = $"Highscore: {ManagerContainer.Instance.Score.Highscore}";
    }

    

}
