using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class GuessClue : MonoBehaviour, IInteraction
{
    public int correctItemId;
    public SpriteRenderer answerSprite;

    private bool isGuessedCorrectly = false;
    public string correctMessage = "";

    private void Awake()
    {
        answerSprite.enabled = false;
    }
    public void Interact()
    {
        if (isGuessedCorrectly == false)
        {
            Item guessItem = Player.Instance.inventory.GetItem();
            if (guessItem != null)
            {
                if (Player.Instance.CheckIfCanGuessYet(correctItemId))
                {
                    if (guessItem.itemId == correctItemId)
                    {
                        CorrectGuess();
                    }
                    else
                    {
                        WrongGuess();
                    }
                }
                else
                {
                    Player.Instance.dialogSpot.StartMessage("I don't think I'm ready to solve this yet...");
                }
            }
        }
    }

    private void CorrectGuess()
    {
        isGuessedCorrectly = true;
        Player.Instance.dialogSpot.StartMessage(correctMessage);
        Player.Instance.ProgressStory();
        GetComponent<SpriteRenderer>().enabled = false;
        answerSprite.enabled = true;
    }

    private void WrongGuess()
    {
        Player.Instance.dialogSpot.StartMessage("This doesn't make a lick of sense?!?!");
    }

}
