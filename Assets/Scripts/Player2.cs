using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float moveSpeed;
    public bool canMove = true;
    public Vector2 bounds = new() { x = -4.2f, y = 4.2f };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void Reset()
    {
        transform.position = new Vector3(5, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance == null || !GameManager.Instance.IsPlaying || !canMove)
            return;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector2.up);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector2.down);
        }

        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, bounds.x, bounds.y);
        transform.position = pos;
    }
}
