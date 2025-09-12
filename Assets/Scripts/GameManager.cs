using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int playerOneScore = 0;
    public int playerTwoScore = 0;
    public int maxScore = 5;

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
        }
    }

    public void IncreasePlayerOneScore()
    {
        playerOneScore++;
        CheckForWin();
    }

    public void IncreasePlayerTwoScore()
    {
        playerTwoScore++;
        CheckForWin();
    }

    private void CheckForWin()
    {
        if (playerOneScore >= maxScore)
        {
            Debug.Log("Player 1 Wins!");
        }
        else if (playerTwoScore >= maxScore)
        {
            Debug.Log("Player 2 Wins!");
        }
    }
}
