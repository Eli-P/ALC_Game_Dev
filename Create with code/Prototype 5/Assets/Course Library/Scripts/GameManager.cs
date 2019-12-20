using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button restart;
    private int score;
    public TextMeshProUGUI text;
    public TextMeshProUGUI gameOver;
    private float spawnRate = 1.0f;
    public List<GameObject> targets;
    public bool isGameActive;
    public GameObject titlescreen;
        void Start()
    {
    }
    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        titlescreen.gameObject.SetActive(false);
        isGameActive = true;
        StartCoroutine(spawnTarget());
        score = 0;
        text.text = "Score: " + score;
        UpdateScore(0);
    }
    void Update()
    {
        
    }
    IEnumerator spawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        text.text = "Score: " + score;
    }
    public void GameOver(){   isGameActive = false; restart.gameObject.SetActive(true); gameOver.gameObject.SetActive(true);}
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
