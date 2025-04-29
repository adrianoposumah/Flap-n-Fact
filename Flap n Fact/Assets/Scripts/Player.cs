using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;
    
    // Add references to the managers
    private GameManager gameManager;
    private QuestionManager questionManager;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Get references to managers
        gameManager = FindObjectOfType<GameManager>();
        questionManager = FindObjectOfType<QuestionManager>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
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
            TriggerPillarAnimation(gemTransform.parent);
            gameManager.GameOver();
        }
    }

    // Updated method to properly trigger animations based on pillar type
    private void TriggerPillarAnimation(Transform pillarParent)
    {
        if (pillarParent == null) return;
        
        // Find all pillar parts
        Transform bottomPillar = pillarParent.Find("BottomPillar");
        Transform middlePillar = pillarParent.Find("MiddlePillar");
        Transform topPillar = pillarParent.Find("TopPillar");
        
        // Trigger BottomPillar animation
        if (bottomPillar != null)
        {
            Animator bottomAnimator = bottomPillar.GetComponent<Animator>();
            if (bottomAnimator != null)
            {
                // Set the WrongAnswer parameter to true
                bottomAnimator.SetBool("WrongAnswer", true);
            }
        }
        
        // Trigger MiddlePillar animations
        if (middlePillar != null)
        {
            // Find the child components
            Transform middleTop = middlePillar.Find("MiddlePillarTop");
            Transform middleBottom = middlePillar.Find("MiddlePillarBottom");
            
            // Trigger animations for middle pillar parts
            if (middleTop != null)
            {
                Animator topAnimator = middleTop.GetComponent<Animator>();
                if (topAnimator != null)
                {
                    topAnimator.SetBool("WrongAnswer", true);
                }
            }
            
            if (middleBottom != null)
            {
                Animator bottomAnimator = middleBottom.GetComponent<Animator>();
                if (bottomAnimator != null)
                {
                    bottomAnimator.SetBool("WrongAnswer", true);
                }
            }
        }
        
        // Trigger TopPillar animation
        if (topPillar != null)
        {
            Animator topAnimator = topPillar.GetComponent<Animator>();
            if (topAnimator != null)
            {
                topAnimator.SetBool("WrongAnswer", true);
            }
        }
        
        // For debugging
        Debug.Log("Triggered wrong answer animations on pillars");
    }
}
