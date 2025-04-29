using UnityEngine;

public class PillarController : MonoBehaviour
{
    private bool isCorrectAnswer;
    private Animator bottomPillarAnimator;
    private Animator topPillarAnimator;
    private Animator middlePillarTopAnimator;
    private Animator middlePillarBottomAnimator;
    
    public void Initialize(bool correctAnswer)
    {
        isCorrectAnswer = correctAnswer;
        
        // Get animators from children
        bottomPillarAnimator = transform.Find("BottomPillar")?.GetComponent<Animator>();
        topPillarAnimator = transform.Find("TopPillar")?.GetComponent<Animator>();
        
        Transform middlePillar = transform.Find("MiddlePillar");
        if (middlePillar != null)
        {
            middlePillarTopAnimator = middlePillar.Find("MiddlePillarTop")?.GetComponent<Animator>();
            middlePillarBottomAnimator = middlePillar.Find("MiddlePillarBottom")?.GetComponent<Animator>();
        }
    }
    
    // Call this when player chooses wrong answer
    public void TriggerWrongAnswerAnimation()
    {
        // Play animation on appropriate pillars based on which one was hit
        if (bottomPillarAnimator != null)
            bottomPillarAnimator.Play("PistonAnimation", 0, 0f);
            
        if (topPillarAnimator != null)
            topPillarAnimator.Play("PistonAnimation", 0, 0f);
            
        if (middlePillarTopAnimator != null)
            middlePillarTopAnimator.Play("PistonAnimation", 0, 0f);
            
        if (middlePillarBottomAnimator != null)
            middlePillarBottomAnimator.Play("PistonAnimation", 0, 0f);
    }
    
    // If you want to play animation for specific pillar only
    public void TriggerPillarAnimation(string pillarName)
    {
        switch(pillarName)
        {
            case "BottomPillar":
                if (bottomPillarAnimator != null)
                    bottomPillarAnimator.Play("PistonAnimation", 0, 0f);
                break;
            case "TopPillar":
                if (topPillarAnimator != null)
                    topPillarAnimator.Play("PistonAnimation", 0, 0f);
                break;
            case "MiddlePillarTop":
                if (middlePillarTopAnimator != null)
                    middlePillarTopAnimator.Play("PistonAnimation", 0, 0f);
                break;
            case "MiddlePillarBottom":
                if (middlePillarBottomAnimator != null)
                    middlePillarBottomAnimator.Play("PistonAnimation", 0, 0f);
                break;
        }
    }
}
