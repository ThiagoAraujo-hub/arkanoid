using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D Body;
    public float Speed;
    public AudioSource Sound;

    public bool GameStarted;

    void Start()
    {
        GameStarted = false;
    }

    void Update()
    {
        if (!GameStarted && Input.GetKeyDown(KeyCode.Space)){
            Move();
            GameStarted = true;
        }
    }

    private void Move(){
        Body.velocity = Vector2.up * Speed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Sound.Play();
    }
}
