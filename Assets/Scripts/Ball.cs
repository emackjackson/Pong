using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float startingSpeed;

    void Start()
    {
        ResetAndLaunch(toRight: Random.value >= 0.5f);
    }

    public void ResetAndLaunch(bool toRight)
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector3.zero;

        float y = Random.Range(-0.8f, 0.8f);
        if (Mathf.Abs(y) < 0.2f) y = Mathf.Sign(Random.value - 0.5f) * 0.2f;

        Vector2 dir = new Vector2(toRight ? 1f : -1f, y).normalized;
        rb.linearVelocity = dir * startingSpeed;
    }
}
