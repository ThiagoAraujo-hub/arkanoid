using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float Speed;
    public Ball Ball;

    public float xMinPosition;
    public float xMaxPosition;

    void Start()
    {
        Ball = FindObjectOfType<Ball>();
    }

    void Update()
    {
        MovePaddle();
    }

    private void MovePaddle()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, xMinPosition, xMaxPosition), transform.position.y);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!Ball.GameStarted){
                Ball.transform.position = new Vector2(Mathf.Clamp(Ball.transform.position.x, xMinPosition, xMaxPosition), Ball.transform.position.y);
                Ball.transform.Translate(Speed * Time.deltaTime * Vector2.left);
            }

            transform.Translate(Speed * Time.deltaTime * Vector2.left);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!Ball.GameStarted){
                Ball.transform.position = new Vector2(Mathf.Clamp(Ball.transform.position.x, xMinPosition, xMaxPosition), Ball.transform.position.y);
                Ball.transform.Translate(Speed * Time.deltaTime * Vector2.right);
            }

            transform.Translate(Speed * Time.deltaTime * Vector2.right);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Ball.GameStarted && other.gameObject.CompareTag("Ball"))
        {
            float hitPosition = (other.transform.position.x - transform.position.x) / (transform.localScale.x / 2);
            Vector2 hitDirection = new Vector2(hitPosition, 1).normalized;

            Ball.GetComponent<Rigidbody2D>().velocity = hitDirection * Ball.Speed;
        }
    }
}
