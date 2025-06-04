using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _velocity = 4.5f;
    [SerializeField] private float _rotationSpeed = 5f;

    private AudioSource flapAudio;
    [SerializeField] private AudioClip hitAudio;
    [SerializeField] private AudioClip pointAudio;

    private GameManager gameManager;
    private QuestionManager questionManager;

    private bool isDead = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        flapAudio = GetComponent<AudioSource>();

        gameManager = FindObjectOfType<GameManager>();
        questionManager = FindObjectOfType<QuestionManager>();
    }

    private void Update()
    {
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _rigidbody.velocity = Vector2.up * _velocity;
            PlayFlapSound();
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                _rigidbody.velocity = Vector2.up * _velocity;
                PlayFlapSound();
            }
        }
    }

    private void FixedUpdate()
    {
        float angle = _rigidbody.velocity.y * _rotationSpeed;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;

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
            StartCoroutine(DelayedGameOver());
        }
    }

    private void HandleGemInteraction(bool isGreenGem, Transform gemTransform)
    {
        if (questionManager.IsAnswerCorrect(isGreenGem))
        {
            gameManager.IncreaseScore();
            questionManager.SetNextQuestion();

            PlayPointSound(); // ✅ Suara poin benar

            Destroy(gemTransform.gameObject);
        }
        else
        {
            StartCoroutine(DelayedGameOver());
        }
    }

    private void PlayFlapSound()
    {
        if (flapAudio != null && flapAudio.clip != null)
        {
            flapAudio.Play();
        }
    }

    private void PlayHitSound()
    {
        if (flapAudio != null && hitAudio != null)
        {
            flapAudio.PlayOneShot(hitAudio);
        }
    }

    private void PlayPointSound()
    {
        if (flapAudio != null && pointAudio != null)
        {
            flapAudio.PlayOneShot(pointAudio);
        }
    }

    private IEnumerator DelayedGameOver()
    {
        isDead = true;

        PlayHitSound(); // ✅ Suara kena obstacle / jawaban salah

        _rigidbody.velocity = Vector2.zero;
        _rigidbody.gravityScale = 1f;
        _rotationSpeed = 10f;

        yield return new WaitForSeconds(1f);

        gameManager.GameOver();
    }
}
