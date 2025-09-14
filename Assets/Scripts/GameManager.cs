using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int playerOneScore = 0;
    public int playerTwoScore = 0;
    public int maxScore = 5;

    [Header("UI")]
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public GameObject MainMenuPanel;
    public GameObject HudPanel;
    public GameObject GameOverPanel;
    public TextMeshProUGUI WinnerText;

    [Header("Scene Refs")]
    public Ball ball;
    public Player1 player1Paddle;
    public Player2 player2Paddle;

    [Header("Difficulty")]
    public TMP_Dropdown speedDropdown;
    public float normalBallSpeed = 7f;
    public float normalPaddleSpeed = 7f;
    public float hardBallSpeed = 9f;
    public float hardPaddleSpeed = 8f;
    public float insaneBallSpeed = 12f;
    public float insanePaddleSpeed = 9f;

    public enum GameState : int
    { 
        MENU, 
        PLAYING,
        GAME_OVER 
    }
    public enum Difficulties : int
    { 
        NORMAL,
        HARD,
        INSANE
    }

    private GameState state = GameState.MENU;
    
    //we use lambda instead of function
    public bool IsPlaying => state == GameState.PLAYING;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        ShowMainMenu();
        UpdateScoreUI();
    }

    private void ShowMainMenu()
    {
        state = GameState.MENU;
        MainMenuPanel.SetActive(true);
        HudPanel.SetActive(false);
        GameOverPanel.SetActive(false);

        StopAndCenterAll();
        ResetScores();
        UpdateScoreUI();
    }

    private void ShowHUD()
    {
        MainMenuPanel.SetActive(false);
        HudPanel.SetActive(true);
        GameOverPanel.SetActive(false);
    }

    private void ShowGameOver(string winnerMsg)
    {
        state = GameState.GAME_OVER;
        WinnerText.text = winnerMsg;
        MainMenuPanel.SetActive(false);
        HudPanel.SetActive(false);
        GameOverPanel.SetActive(true);

        StopAndCenterAll();
    }

    public void StartMatch()
    {
        ResetScores();
        UpdateScoreUI();

        ApplyDifficulty();
        ShowHUD();
        state = GameState.PLAYING;

        player1Paddle.Reset();
        player2Paddle.Reset();
        ball.ResetAndLaunch();
    }

    public void BackToMenu()
    {
        ShowMainMenu();
    }

    public void IncreasePlayerOneScore()
    {
        if (!IsPlaying) 
            return;

        playerOneScore++;
        UpdateScoreUI();
        CheckForWin();

        if (IsPlaying) 
            NextServe();
    }

    public void IncreasePlayerTwoScore()
    {
        if (!IsPlaying) 
            return;

        playerTwoScore++;
        UpdateScoreUI();
        CheckForWin();

        if (IsPlaying) 
            NextServe();
    }

    private void UpdateScoreUI()
    {
        player1ScoreText.text = playerOneScore.ToString();
        player2ScoreText.text = playerTwoScore.ToString();
    }

    private void ResetScores()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
    }

    private void CheckForWin()
    {
        if (playerOneScore >= maxScore)
            ShowGameOver("Player 1 Wins!");
        else if (playerTwoScore >= maxScore)
            ShowGameOver("Player 2 Wins!");
    }

    private void NextServe()
    {
        player1Paddle.Reset();
        player2Paddle.Reset();
        ball.ResetAndLaunch();
    }

    public void SetPaddlesCanMove(bool value)
    {
        player1Paddle.canMove = value;
        player2Paddle.canMove = value;
    }

    private void StopAndCenterAll()
    {
        ball.rb.linearVelocity = Vector2.zero;
        ball.transform.position = Vector3.zero;

        player1Paddle.Reset();
        player2Paddle.Reset();
    }

    private void ApplyDifficulty()
    {
        int choice = speedDropdown.value;

        switch (choice)
        {
            case (int)Difficulties.NORMAL:
                ball.startingSpeed = normalBallSpeed;
                player1Paddle.moveSpeed = normalPaddleSpeed;
                player2Paddle.moveSpeed = normalPaddleSpeed;
                break;
            case (int)Difficulties.HARD:
                ball.startingSpeed = hardBallSpeed;
                player1Paddle.moveSpeed = hardPaddleSpeed;
                player2Paddle.moveSpeed = hardPaddleSpeed;
                break;
            case (int)Difficulties.INSANE:
                ball.startingSpeed = insaneBallSpeed;
                player1Paddle.moveSpeed = insanePaddleSpeed;
                player2Paddle.moveSpeed = insanePaddleSpeed;
                break;
        }
    }
}