using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delay = 2f;

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameSession>().Reset();
    }

    IEnumerator DelayGameOver()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Game Over");
    }

    public void LoadGameOver()
    {
        StartCoroutine(DelayGameOver());    
    }

    

    public void QuitGame()
    {
        Application.Quit();
    }
}
