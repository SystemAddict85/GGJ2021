using TMPro;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class Corkboard : MonoBehaviour, IInteraction
{
    [SerializeField]
    private Transform corkboardMapTransform;

    private TextMeshProUGUI buttonHelpText;

    private bool _isPlayerInCorkboard = false;


    private void Awake()
    {
        
    }

    private void Start()
    {
        buttonHelpText = UIManager.Instance.buttonHelpText;
        buttonHelpText.enabled = false;
    }


    public void Interact()
    {
        Player.Instance.transform.position = corkboardMapTransform.position;
        _isPlayerInCorkboard = true;
        buttonHelpText.enabled = true;
    }

    private void Update()
    {
        if (_isPlayerInCorkboard && Input.GetKeyDown(KeyCode.Backspace) && Player.Instance.CanMove)
        {
            Player.Instance.transform.position = transform.position;
            _isPlayerInCorkboard = false;
            buttonHelpText.enabled = false;
        }
    }
}
