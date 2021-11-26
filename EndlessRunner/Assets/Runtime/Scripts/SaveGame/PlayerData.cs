using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private GameMode gameMode;
    [SerializeField] private TextMeshProUGUI lastScoreValue;
    [SerializeField] private TextMeshProUGUI pickUpCollected;
    [SerializeField] private TextMeshProUGUI highScoreValue;
    public void SaveStates()
    {
        int previousScore = PlayerPrefs.GetInt("HighScore");
        int totalScore = previousScore + gameMode.Score;
        PlayerPrefs.SetInt("Score", gameMode.Score);
        PlayerPrefs.SetInt("PickUps", gameMode.TotalCoins);
        PlayerPrefs.SetInt("HighScore", totalScore);  
    }
    public void LoadStates()
    {
        lastScoreValue.text = " " + PlayerPrefs.GetInt("Score");
        pickUpCollected.text = " " + PlayerPrefs.GetInt("PickUps");
        highScoreValue.text = " " + PlayerPrefs.GetInt("HighScore");
        
    }

   
}
