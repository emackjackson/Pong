using UnityEngine;
public class UpdatePlayer1Score : MonoBehaviour
{
    //ref to ball
    public Ball ball;
    public Player1 player1Paddle;
    public Player2 player2Paddle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ball"))
        {
            GameManager.Instance.IncreasePlayerOneScore();

            ball.ResetAndLaunch();
            player1Paddle.Reset();
            player2Paddle.Reset();
        }
    }
}
