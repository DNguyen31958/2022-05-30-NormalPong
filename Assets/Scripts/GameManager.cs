using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource endSound;
    public Ball ball;
    public TMP_Text countdownText;
    private bool isGameEnd;

    public PlayerPaddle playerPaddle;
    public TMP_Text playerScoreText;
    private int playerScore;

    public ComputerPaddle computerPaddle;
    public TMP_Text computerScoreText;
    private int computerScore;

    private void Start()
    {
        StartCoroutine(CountDownCoroutine());
    }

    public void NewGame()
    {
        playerScore = 0;
        computerScore = 0;
        playerScoreText.text = "P1: " + playerScore;
        computerScoreText.text = "Computer: " + computerScore;
        StartRound();
    }

    public void StartRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetPosition();
        ball.AddStartingForce();
    }

    public void PlayerScores()
    {
        playerScore = playerScore + 1;
        playerScoreText.text = "P1: " + playerScore;
        StartRound();
    }

    public void ComputerScores()
    {
        computerScore = computerScore + 1;
        computerScoreText.text = "Computer: " + computerScore;
        StartRound();
    }

    IEnumerator CountDownCoroutine()
    {
        playerScoreText.text = "";
        computerScoreText.text = "";
        countdownText.text = "Starting in: 3";
        yield return new WaitForSeconds(1.0f);
        countdownText.text = "Starting in: 2";
        yield return new WaitForSeconds(1.0f);
        countdownText.text = "Starting in: 1";
        yield return new WaitForSeconds(1.0f);
        countdownText.text = "GO!";
        yield return new WaitForSeconds(1.0f);
        countdownText.text = "";
        yield return null;
        NewGame();
    }

    private void Update()
    {
        if ((playerScore == 3 || computerScore == 3) && isGameEnd == false)
        {
            endSound.Play();
            Time.timeScale = 0;
            if (playerScore == 3)
            {
                countdownText.text = "Winner: Player\nPress R to play again";
            }
            else if (computerScore == 3)
            {
                countdownText.text = "Winner: Computer\nPress R to play again";
            }
            playerScore = 0;
            computerScore = 0;
            isGameEnd = true;
        }
        if (Input.GetKeyDown(KeyCode.R) == true && isGameEnd == true)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Game");
        }
    }
}
