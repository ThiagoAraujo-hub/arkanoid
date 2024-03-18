using UnityEngine;

public class Block : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<GameManager>().AddBlock();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            FindObjectOfType<GameManager>().RemoveBlock();
            Destroy(gameObject);
        }
    }
}
