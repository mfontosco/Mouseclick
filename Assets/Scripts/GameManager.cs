using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    ///private SceneManager sceneManager;
    public List<GameObject> prefabs;
    private float spawnRate = 1f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public Button restartBtn;
    public bool isGameActive;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnTargets());
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore(int ScoreToAdd)
    {
        score += ScoreToAdd;
        scoreText.text = "Score:" + score;
    }

    IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, prefabs.Count);
            Instantiate(prefabs[index]);
            
        }
        
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartBtn.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        titleScreen.gameObject.SetActive(true);
    }
}
