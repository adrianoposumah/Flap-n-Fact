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
        
        // Setup the pillar animators
        SetupPillarAnimations(pillars, correctAnswer);
    }
    
    private void SetupPillarAnimations(GameObject pillars, bool correctAnswer)
    {
        // Find child pillar GameObjects
        Transform bottomPillar = pillars.transform.Find("BottomPillar");
        Transform middlePillar = pillars.transform.Find("MiddlePillar");
        Transform topPillar = pillars.transform.Find("TopPillar");
        Transform greenGem = pillars.transform.Find("GreenGem");
        Transform redGem = pillars.transform.Find("RedGem");
        
        // Get middle pillar components
        Transform middlePillarTop = null;
        Transform middlePillarBottom = null;
        if (middlePillar != null)
        {
            middlePillarTop = middlePillar.Find("MiddlePillarTop");
            middlePillarBottom = middlePillar.Find("MiddlePillarBottom");
        }
        
        // Add a PillarController script to the parent to handle animations
        PillarController controller = pillars.AddComponent<PillarController>();
        
        // Set the correct answer status
        controller.Initialize(correctAnswer);
    }
}
