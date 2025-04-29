using UnityEngine;

public class Pillars : MonoBehaviour
{
    public float speed = 5f;
    public float leftEdge;
    private Vector3 direction;

    private void Start()
    {
        direction = Vector3.left * speed;
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        transform.position += direction * Time.deltaTime;
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
