using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector2.up);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector2.down);
        }
    }
}
