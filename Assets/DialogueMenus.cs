using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMenus : MonoBehaviour
{
    [SerializeField] private List<Prompt> prompts = new List<Prompt>();

    private void Start()
    {
        foreach (var prompt in prompts)
        {
            if (prompt.alwaysVisible)
            {
                prompt.SetVisible(true);
            }
            else
            {
                prompt.SetVisible(false);
            }

            // Ensure the BoxCollider2D is set as a trigger
            if (prompt.collisionBox != null)
            {
                prompt.collisionBox.isTrigger = true;
            }
        }
    }
}

[System.Serializable]
public class Prompt
{
    [Header("Prompt Details")]
    public string promptName; // Name to identify the prompt
    public Vector2 position; // Position of the prompt
    public bool alwaysVisible; // If true, always visible
    public bool isTriggeredByCollision; // If true, visibility is triggered by collision

    [Header("Conditional Settings")]
    public bool condition = true; // A custom condition for visibility

    [Header("Dialogue Settings")]
    [TextArea(3, 5)] // Makes the text area larger in the inspector
    public string dialogueText; // The dialogue content for the prompt

    [Header("References")]
    public GameObject promptObject; // Reference to the prompt's GameObject
    public Text dialogueUI; // UI Text component to display the dialogue
    public BoxCollider2D collisionBox; // BoxCollider2D for collision detection

    public void SetVisible(bool isVisible)
    {
        if (promptObject != null)
        {
            promptObject.SetActive(isVisible && condition);

            if (dialogueUI != null)
            {
                dialogueUI.text = dialogueText; // Set the dialogue text on the UI
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!alwaysVisible && isTriggeredByCollision)
            {
                SetVisible(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!alwaysVisible)
            {
                SetVisible(false);
            }
        }
    }
}
