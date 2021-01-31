using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private SpriteOutline _outline;
    private bool _isPlayerInRange = false;

    public InteractionInput _input = new InteractionInput();

    public List<IInteraction> _interactions;
    private void Awake()
    {
        _outline = GetComponentInChildren<SpriteOutline>();
        _isPlayerInRange = false;
        _interactions = GetComponents<IInteraction>().ToList();
    }

    private void Update()
    {
        CheckForPlayerInteraction();
    }

    private void CheckForPlayerInteraction()
    {
        if (_isPlayerInRange && _input.IsPlayerInteracting)
        {
            foreach(var interact in _interactions)
                interact.Interact();
        }
    }

    private void PlayerEnters()
    {
        _isPlayerInRange = true;
        _outline.ToggleOutline(true);
    }

    private void PlayerExits()
    {
        _isPlayerInRange = false;
        _outline.ToggleOutline(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerEnters();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerExits();
        }
    }
}

public class InteractionInput
{
    public bool IsPlayerInteracting { get { return Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space); } }
}
