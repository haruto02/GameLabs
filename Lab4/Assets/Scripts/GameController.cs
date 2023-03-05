using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float xMinMax = 5.0f, zMin = 15.5f;
    public GameObject rock;
    public int count;
    public float startWait, waveWait, cloneWait;

    public TextMeshProUGUI scoreText, gameOverText, restartText;
    private int score;
    private bool gameOver, restart;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gameOver = restart = false;
        scoreText.text = "Score: 0";
        restartText.text = "";
        gameOverText.text = "";
        StartCoroutine(Waves());
    }
    void Update()
    {
        if (restart && Input.GetKeyDown(KeyCode.S)) {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    IEnumerator Waves()
    {
        while (true) { 
            yield return new WaitForSeconds(startWait);
            for (int i = 0; i < count; i++)
            {
                Instantiate(rock, new Vector3(Random.Range(-xMinMax, xMinMax), 1, zMin), Quaternion.identity);
                yield return new WaitForSeconds(cloneWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restart = true;
                restartText.text = "Press 'S' to restart.";
                break;
            }
        }
    }

    public void addScore(int sc)
    {
        score += sc;
        scoreText.text = "Score:" + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game over!";
        gameOver = true;
    }
}
