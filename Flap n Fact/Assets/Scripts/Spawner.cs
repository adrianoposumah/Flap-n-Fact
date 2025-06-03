using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 4f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), 0f, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pillars = Instantiate(prefab, transform.position, Quaternion.identity);
        pillars.transform.position = new Vector3(
            transform.position.x, 
            Random.Range(minHeight, maxHeight), 
            transform.position.z
        );

        QuestionManager questionManager = FindObjectOfType<QuestionManager>();
        bool correctAnswer = questionManager.IsAnswerCorrect(true);
        
    }
    

}
