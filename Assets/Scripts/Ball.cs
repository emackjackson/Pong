using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float startingSpeed = 7f;

    void Start()
    {

    }

    public void ResetAndLaunch()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector3.zero;

        StartCoroutine(LaunchAfterDelay(1f));
    }

    private IEnumerator LaunchAfterDelay(float delay)
    {
        GameManager.Instance.SetPaddlesCanMove(false);

        yield return new WaitForSeconds(delay);

        if (GameManager.Instance == null || !GameManager.Instance.IsPlaying)
            yield break;

        GameManager.Instance.SetPaddlesCanMove(true);

        float xVelocity = (Random.value >= 0.5f) ? 1f : -1f;
        float yVelocity = Random.Range(-1f, 1f);

        if (Mathf.Abs(yVelocity) < 0.2f)
            yVelocity = Mathf.Sign(yVelocity == 0 ? (Random.value - 0.5f) : yVelocity) * 0.2f;

        rb.linearVelocity = new Vector2(xVelocity * startingSpeed, yVelocity * startingSpeed);
    }
}
