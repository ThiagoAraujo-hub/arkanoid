using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    GameManager GameManager;

    void Start(){
        GameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameManager.SendMessage("RemoveLife");
        }
    }
}
