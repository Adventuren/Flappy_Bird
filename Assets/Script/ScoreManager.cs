using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager 
{
    
    public ScoreUI ScoreUI { get; set; }
    public EventHandler ScoreUpdatedEvent;
    public EventHandler HighScoreUpdatedEvent;
    public int Score { get; private set; }
    public int Highscore { get; private set; }
   


    public void AddScore()
    {
        Score++;
    }

    public void UpdateHighScore()
    {
        Highscore = Score;
        PlayerPrefs.SetInt("Highscore", Highscore);
    }

    public bool AllowUpdateHighScore()
    {
        return Score > Highscore;

    }

    public void Build()
    {
        Score = 0;
        if (PlayerPrefs.HasKey("Highscore"))
        {
            Highscore = PlayerPrefs.GetInt("Highscore");
        } 
        else
        {
            PlayerPrefs.SetInt("Highscore", 0);
            Highscore = PlayerPrefs.GetInt("Highscore");
        }

        ScoreUI.AddEvent();
    }

    public void OnScoreUpdated(object sender, EventArgs e)
    {
        ScoreUpdatedEvent.Invoke(this, e);
        if(AllowUpdateHighScore())
        {
            UpdateHighScore();
            HighScoreUpdatedEvent.Invoke(this, e);
        }
    }

    
}
