using System.Collections;
using UnityEngine;

public class PromptManager : MonoBehaviour
{
    public void ShowPrompt(GameObject prompt)
    {
        if (prompt != null)
        {
            prompt.SetActive(true);
        }
    }

    public void HidePrompt(GameObject prompt)
    {
        if (prompt != null)
        {
            prompt.SetActive(false);
        }
    }

    public IEnumerator ShowWithAnimation(GameObject prompt, Animator animator, string animationTrigger, float duration)
    {
        if (prompt != null && animator != null)
        {
            ShowPrompt(prompt);
            animator.SetTrigger(animationTrigger);
            yield return new WaitForSeconds(duration);
        }
    }

    public IEnumerator HideWithAnimation(GameObject prompt, Animator animator, string animationTrigger, float duration)
    {
        if (prompt != null && animator != null)
        {
            animator.SetTrigger(animationTrigger);
            yield return new WaitForSeconds(duration);
            HidePrompt(prompt);
        }
    }
}
