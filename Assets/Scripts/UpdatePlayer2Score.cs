using UnityEngine;
public class UpdatePlayer2Score : MonoBehaviour
{
    //ref to ball
    public Ball ball;

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
            Debug.Log("Ball collided with " + gameObject.name);

            GameManager.Instance.IncreasePlayerTwoScore();
            ball.ResetAndLaunch();
        }
    }
}
