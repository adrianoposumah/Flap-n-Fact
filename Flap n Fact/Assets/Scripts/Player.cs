using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _velocity = 4.5f;
    [SerializeField] private float _rotationSpeed = 5f;
    
    // Add references to the managers
    private GameManager gameManager;
    private QuestionManager questionManager;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        
        // Get references to managers
        gameManager = FindObjectOfType<GameManager>();
        questionManager = FindObjectOfType<QuestionManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _rigidbody.velocity = Vector2.up * _velocity;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                _rigidbody.velocity = Vector2.up * _velocity;
            }
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rigidbody.velocity.y * _rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GreenGem"))
        {
            HandleGemInteraction(true, collision.transform);
        }
        else if (collision.CompareTag("RedGem"))
        {
            HandleGemInteraction(false, collision.transform);
        }
        else if (collision.CompareTag("Obstacle"))
        {
            gameManager.GameOver();
        }
    }

    private void HandleGemInteraction(bool isGreenGem, Transform gemTransform)
    {
        if (questionManager.IsAnswerCorrect(isGreenGem))
        {
            gameManager.IncreaseScore();
            questionManager.SetNextQuestion();

            // Optional: efek partikel untuk gem
            Destroy(gemTransform.gameObject);
        }
        else
        {
            gameManager.GameOver();
        }
    }
}
