using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    Text scoreText;
    GameSession gameSession;

    
    void Start()
    {
        scoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        scoreText.text = gameSession.GetScore().ToString();
    }
}
