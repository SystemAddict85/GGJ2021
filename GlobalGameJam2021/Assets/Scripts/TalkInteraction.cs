using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class TalkInteraction : MonoBehaviour, IInteraction
{
    public string dialogue;
    private DialogSpot _spot;
    private void Awake()
    {
        _spot = GetComponentInChildren<DialogSpot>();
    }

    public void Interact()
    {
        Talk();
    }

    public void Talk(string message = "")
    {
        if (message == "")
            _spot.StartMessage(dialogue);
        else
            _spot.StartMessage(message);
    }
}
