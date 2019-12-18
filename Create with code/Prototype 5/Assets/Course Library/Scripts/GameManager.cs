using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI text;
    public TextMeshProUGUI gameOver;
    private float spawnRate = 1.0f;
    public List<GameObject> targets;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnTarget());
        score = 0;
        text.text = "Score: " + score;
        UpdateScore(0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawnTarget()
    {
        while (true)
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
    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
    }
    
}
