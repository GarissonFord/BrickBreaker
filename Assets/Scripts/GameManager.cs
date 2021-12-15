using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameCompleteScreen;
    public GameObject gameOverScreen;
    public List<GameObject> bricks;
    public int numberOfBricks;
    public bool isGameActive;

    public LevelGenerator levelGenerator;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        gameCompleteScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        numberOfBricks = bricks.Count;
        levelGenerator = GameObject.Find("Bricks").GetComponent<LevelGenerator>();
        numberOfBricks = levelGenerator.rows * levelGenerator.columns;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfBricks == 0 && isGameActive)
            GameComplete();
    }

    public void BrickBroken()
    {
        numberOfBricks--;
    }

    public void GameComplete()
    {
        isGameActive = false;
        gameCompleteScreen.SetActive(true);
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
