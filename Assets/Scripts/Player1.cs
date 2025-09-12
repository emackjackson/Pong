using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector2.up);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector2.down);
        }
    }
}
