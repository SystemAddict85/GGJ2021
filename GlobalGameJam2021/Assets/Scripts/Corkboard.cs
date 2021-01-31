using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class Corkboard : MonoBehaviour, IInteraction
{
    public void Interact()
    {
        Debug.Log("Corkboard interacted with");
    }
   
}
