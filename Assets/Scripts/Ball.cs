using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float startingSpeed;

    void Start()
    {
        ResetAndLaunch();
    }

    public void ResetAndLaunch()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector3.zero;

        float xVelocity = (UnityEngine.Random.value >= 0.5f) ? 1f : -1f;
        float yVelocity = UnityEngine.Random.Range(-1f, 1f);

        if (Mathf.Abs(yVelocity) < 0.2f)
            yVelocity = Mathf.Sign(yVelocity == 0 ? (Random.value - 0.5f) : yVelocity) * 0.2f;

        rb.linearVelocity = new Vector2(xVelocity * startingSpeed, yVelocity * startingSpeed);
    }
}
