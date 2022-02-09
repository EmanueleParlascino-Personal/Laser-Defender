using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{

    int score = 0;
    

    void Awake()
    {
        SetUpSingleton();
    }

     private void SetUpSingleton()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if (numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    

    public void AddtoScore(int value)
    {
        score += value;
    }


    public void Reset()
    {
        Destroy(gameObject);
    }
}
