using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {
    //the game logic
    private static Game singleton;

    [SerializeField]
    RobotSpawn[] spawns;

    //how many enemies are left
    public int robotsLeft;
    //UI
    public GameUI gameUI;
    //player
    public GameObject player;
    //UI elements
    public int score;
    public int WaveCountdown;
    //game state
    public bool isGameOver;
    //the game over panel
    public GameObject gameOverPanel;

    private int countdownValue;

	// Use this for initialization
	void Start () {
        singleton = this;
        StartCoroutine("GivePointPerSecond");
        Time.timeScale = 1;//normal time
        robotsLeft = 0;
        StartCoroutine("UpdateWaveCountdown");
        SpawnRobots();
        countdownValue = WaveCountdown;
    }
	
	// Update is called once per frame
	void Update () {

	}

    //spawn robots in each spawn
    private void SpawnRobots()
    {
        foreach(RobotSpawn spawn in spawns)
        {
            spawn.SpawnRobot();
            robotsLeft++;
        }
        gameUI.SetEnemyText(robotsLeft);
    }

    //update the wave timer as long as the round isnt over
    private IEnumerator UpdateWaveCountdown()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1f);
            --WaveCountdown;
            gameUI.SetNextWaveText(WaveCountdown);
            //check if its time to spawn the next wave
            if (WaveCountdown == 0)
            {
                WaveCountdown = countdownValue;
                SpawnRobots();
                gameUI.ShowNewWaveText();
            }
        }


    }

    //method to decrement the enemies remaining text
    public static void RemoveEnemy()
    {
        singleton.robotsLeft--;
        singleton.gameUI.SetEnemyText(singleton.robotsLeft);
        if(singleton.robotsLeft == 0)//bonus for wave clear
        {
            singleton.score += 50;
            singleton.gameUI.SetScore(singleton.score);
        }
        singleton.AddRobotKill();
    }
    //give points for robot kill
    public void AddRobotKill()
    {
        score += 10;
        gameUI.SetScore(score);
    }

    //also give 1 point per second
    IEnumerator GivePointPerSecond()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1f);
            score += 1;
            gameUI.SetScore(score);
        }
    }

    //handle gameover
    public void OnGUI()//reenable cursor
    {
        if(isGameOver && Cursor.visible == false)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0.2f;//slow things downs
        //disable current weapon
        player.GetComponentInChildren<Gun>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<FirstPersonController>().enabled = false;
        gameOverPanel.SetActive(true);

    }

    //handle panel button presses
    public void RestartGame()
    {
        SceneManager.LoadScene(Constants.SceneBattle);
        gameOverPanel.SetActive(false);
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene(Constants.SceneMenu);
       
    }

    public void Quit()
    {
        Application.Quit();
    }
}
